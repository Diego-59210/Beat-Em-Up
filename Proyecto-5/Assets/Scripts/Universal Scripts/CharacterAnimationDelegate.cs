using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject rightHandAttackPoint, leftHandAttackPoint, rightLegAttackPoint, leftLegAttackPoint;

    public float standUpTimer = 2f;
    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whooshSound, fallSound, groundHitSound, deadSound;


    private EnemyMovement enemyMovementScript;
    private CameraShake cameraShake;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovementScript = GetComponentInParent<EnemyMovement>();
        }
        cameraShake = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
    }

    void LeftHandAttackON()
    {
        leftHandAttackPoint.SetActive(true);
    }
    void LeftHandAttackOFF()
    {
        if(leftHandAttackPoint.activeInHierarchy)
        {
            leftHandAttackPoint.SetActive(false);
        }
    }
    void RightHandAttackON()
    {
        rightHandAttackPoint.SetActive(true);
    }
    void RightHandAttackOFF()
    {
        if (rightHandAttackPoint.activeInHierarchy)
        {
            rightHandAttackPoint.SetActive(false);
        }
    }
    void LeftLegAttackON()
    {
        leftLegAttackPoint.SetActive(true);
    }
    void LeftLegAttackOFF()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }
    void RightLegAttackON()
    {
        rightLegAttackPoint.SetActive(true);
    }
    void RightLegAttackOFF()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }
    void TagLeftArm()
    {
        leftHandAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }
    void UntagLeftArm()
    {
        leftHandAttackPoint.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }
    void UntagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
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
    void EnemyKnockedDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }
    void EnemyHitGround()
    {
        audioSource.clip = groundHitSound;
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
