using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponentInParent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("MapBound"))
        {

            TakeDamage(100);
        }
    }

    public void TakeDamage(float damage)
    {
        if (GameManager.instance.ChangeHealth(-damage))
        {
            Die();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        bc.enabled = false;
        anim.SetTrigger("death");
    }

    private void RespawnPlayer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.parent.transform.position = startPos;
        bc.enabled = true;
        GameManager.instance.ChangeHealth(100);
        anim.SetTrigger("respawned");
    }
}
