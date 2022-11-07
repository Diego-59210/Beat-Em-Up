using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ComboState
{
        NONE,
        LIGHT_ATTACK_1,
        LIGHT_ATTACK_2,
        LIGHT_ATTACK_3,
        HEAVY_ATTACK_1,
        HEAVY_ATTACK_2,

}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.8f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    // Start is called before the first frame update
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }
    // Update is called once per frame
    void Update()
    {
        ComboAttack();
        ResetComboState();
        
    }
    void ComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (current_Combo_State == ComboState.LIGHT_ATTACK_3 || current_Combo_State == ComboState.HEAVY_ATTACK_1 || current_Combo_State == ComboState.HEAVY_ATTACK_2)

                return;

            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            if (current_Combo_State == ComboState.LIGHT_ATTACK_1)
            {
                player_Anim.LightAttack_1();
            }
            if (current_Combo_State == ComboState.LIGHT_ATTACK_2)
            {
                player_Anim.LightAttack_2();
            }
            if (current_Combo_State == ComboState.LIGHT_ATTACK_3)
            {
                player_Anim.LightAttack_3();
            }
        }
        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            if (current_Combo_State == ComboState.HEAVY_ATTACK_2 || current_Combo_State == ComboState.LIGHT_ATTACK_3)
                return;
            if(current_Combo_State == ComboState.NONE || current_Combo_State == ComboState.LIGHT_ATTACK_1 || current_Combo_State == ComboState.LIGHT_ATTACK_2)
            {
                current_Combo_State = ComboState.HEAVY_ATTACK_1;
            }
            else if(current_Combo_State == ComboState.HEAVY_ATTACK_1)
            {
                current_Combo_State++;
            }
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            if (current_Combo_State == ComboState.HEAVY_ATTACK_1)
            {
                player_Anim.HeavyAttack_1();
            }
            if (current_Combo_State == ComboState.HEAVY_ATTACK_2)
            {
                player_Anim.HeavyAttack_2();
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
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
