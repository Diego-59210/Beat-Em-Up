using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }
    public void LightAttack_1()
    {
        anim.SetTrigger(AnimationTags.LIGHT_ATTACK_1_TRIGGER);
    }
    public void LightAttack_2()
    {
        anim.SetTrigger(AnimationTags.LIGHT_ATTACK_2_TRIGGER);
    }
    public void LightAttack_3()
    {
        anim.SetTrigger(AnimationTags.LIGHT_ATTACK_3_TRIGGER);
    }
    public void HeavyAttack_1()
    {
        anim.SetTrigger(AnimationTags.HEAVY_ATTACK_1_TRIGGER);
    }
    public void HeavyAttack_2()
    {
        anim.SetTrigger(AnimationTags.HEAVY_ATTACK_2_TRIGGER);
    }
    public void HeavyAttack_3()
    {
        anim.SetTrigger(AnimationTags.HEAVY_ATTACK_3_TRIGGER);
    }
    public void PlayerHurt()
    {
        anim.SetTrigger(AnimationTags.PLAYER_HURT_TRIGGER);
    }
    
    //Enemy Animations
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);
        }
    }
    public void PlayIdleAnimation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }
    public void Death()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
