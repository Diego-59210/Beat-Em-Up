using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDelegate : MonoBehaviour
{
    public GameObject enemyAttackPoint1, enemyAttackPoint2, enemyAttackPoint3;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip attackSound, hitSound, deadSound;


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
        cameraShake = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
    }

    void EnemyAttack1ON()
    {
        enemyAttackPoint1.SetActive(true);
    }
    void EnemyAttack1OFF()
    {
        if (enemyAttackPoint1.activeInHierarchy)
        {
            enemyAttackPoint1.SetActive(false);
        }
    }
    void EnemyAttack2ON()
    {
        enemyAttackPoint2.SetActive(true);
    }
    void EnemyAttack2OFF()
    {
        if (enemyAttackPoint2.activeInHierarchy)
        {
            enemyAttackPoint2.SetActive(false);
        }
    }
    void EnemyAttack3ON()
    {
        enemyAttackPoint3.SetActive(true);
    }
    void EnemyAttack3OFF()
    {
        if (enemyAttackPoint3.activeInHierarchy)
        {
            enemyAttackPoint3.SetActive(false);
        }
    }
    public void EnemyAttackSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = attackSound;
        audioSource.Play();
    }
    public void EnemyHitSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = hitSound;
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
        //transform.parent.gameObject.layer = 0;
    }
    void EnableMovement()
    {
        enemyMovementScript.enabled = true;
        //transform.parent.gameObject.layer = 7;
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
