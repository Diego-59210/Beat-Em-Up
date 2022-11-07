using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate2D : MonoBehaviour
{
    public GameObject swordAttackPoint;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip attack1Sound, attack2Sound, walkSound, playerHit, deadSound, shootSound;


    private PlayerMovement2D MovementScript;
    private EnemyMovement enemyMovementScript;
    private CameraShake cameraShake;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovementScript = GetComponentInParent<EnemyMovement>();
        }
        if (gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            MovementScript = GetComponentInParent<PlayerMovement2D>();
        }
        cameraShake = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
    }

    void SwordAttackON()
    {
        swordAttackPoint.SetActive(true);
    }
    void SwordAttackOFF()
    {
        if(swordAttackPoint.activeInHierarchy)
        {
            swordAttackPoint.SetActive(false);
        }
    }
    public void Attack1FXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = attack1Sound;
        audioSource.Play();
    }
    public void Attack2FXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = attack2Sound;
        audioSource.Play();
    }
    public void WalkingSoundOn()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = walkSound;
        audioSource.Play();
    }
    public void WalkingSoundOff()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = walkSound;
        audioSource.Stop();
    }
    public void ShootSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = shootSound;
        audioSource.Play();
    }
    public void PlayerHitSound()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = playerHit;
        audioSource.Play();
    }
    void CharacterDied()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }
    void DisableMovement()
    {
        enemyMovementScript.enabled = false;
        transform.parent.gameObject.layer = 0;
    }
    void EnableMovement()
    {
        enemyMovementScript.enabled = true;
        transform.parent.gameObject.layer = 7;
    }
    void DisablePlayerMovement()
    {
        MovementScript.enabled = false;
    }
    void EnablePlayerMovement()
    {
        MovementScript.enabled = true;
    }
    void ShakeCameraOnFall()
    {
        cameraShake.ShouldShake = true;
    }
    void CharacterDeath()
    {
        Invoke("DeactivateGameObject", 2f);
    }
    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
