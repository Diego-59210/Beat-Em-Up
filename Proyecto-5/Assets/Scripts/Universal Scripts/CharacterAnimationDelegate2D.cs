using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate2D : MonoBehaviour
{
    public GameObject swordAttackPoint;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whooshSound, fallSound, deadSound;


    private EnemyMovement enemyMovementScript;
    private CameraShake cameraShake;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        //audioSource = GetComponent<AudioSource>();
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovementScript = GetComponentInParent<EnemyMovement>();
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
    public void AttackFXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }
    void CharacterDied()
    {
        audioSource.volume = 1f;
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
