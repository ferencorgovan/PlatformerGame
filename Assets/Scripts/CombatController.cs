using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatController : MonoBehaviour
{
    public Animator anim;
    public void Attack(InputAction.CallbackContext context)
    {
        if (!anim.GetBool("isSitting") && context.performed)
        {
            anim.SetTrigger("attack");
        }
    }
}
