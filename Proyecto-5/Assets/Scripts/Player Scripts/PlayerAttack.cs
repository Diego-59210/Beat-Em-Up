using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LightComboState
{
        NONE,
        LIGHT_ATTACK_1,
        LIGHT_ATTACK_2,
        LIGHT_ATTACK_3,
   
}
public enum HeavyComboState
{
    NONE,
    HEAVY_ATTACK_1,
    HEAVY_ATTACK_2,
    HEAVY_ATTACK_3,

}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.5f;
    private float current_Combo_Timer;

    private LightComboState current_LightCombo_State;
    private HeavyComboState current_HeavyCombo_State;

    // Start is called before the first frame update
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_LightCombo_State = LightComboState.NONE;
        current_HeavyCombo_State = HeavyComboState.NONE;
    }
    // Update is called once per frame
    void Update()
    {
        LightComboAttack();
        ResetComboState();
        
    }
    void LightComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (current_LightCombo_State == LightComboState.LIGHT_ATTACK_3)

                return;

            current_LightCombo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            if (current_LightCombo_State == LightComboState.LIGHT_ATTACK_1)
            {
                player_Anim.LightAttack_1();
            }
            if (current_LightCombo_State == LightComboState.LIGHT_ATTACK_2)
            {
                player_Anim.LightAttack_2();
            }
            if (current_LightCombo_State == LightComboState.LIGHT_ATTACK_3)
            {
                player_Anim.LightAttack_3();
            }
        }
     
    }
    void HeavyComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (current_HeavyCombo_State == HeavyComboState.HEAVY_ATTACK_3)

                return;

            current_HeavyCombo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            if (current_HeavyCombo_State == HeavyComboState.HEAVY_ATTACK_1)
            {
                player_Anim.HeavyAttack_1();
            }
            if (current_HeavyCombo_State == HeavyComboState.HEAVY_ATTACK_2)
            {
                player_Anim.HeavyAttack_2();
            }
            if (current_HeavyCombo_State == HeavyComboState.HEAVY_ATTACK_3)
            {
                player_Anim.HeavyAttack_3();
            }
        }

    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if (current_Combo_Timer <= 0f)
            {
                current_LightCombo_State = LightComboState.NONE;
                current_HeavyCombo_State = HeavyComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
