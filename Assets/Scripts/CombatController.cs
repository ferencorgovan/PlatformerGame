using UnityEngine;
using UnityEngine.InputSystem;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Attack(InputAction.CallbackContext context)
    {
        if (!anim.GetBool("isSitting") && context.performed)
        {
            anim.SetTrigger("attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(GameManager.instance.GetDamage());
        }
    }
}
