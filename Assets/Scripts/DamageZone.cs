using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private float damagePerSecond = 150f;
    private PlayerLife playerLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerLife = collision.GetComponentInChildren<PlayerLife>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerLife != null)
        {
            playerLife.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
