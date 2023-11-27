using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerLife playerLife;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private HealthBar healthBar;

    [SerializeField] private EdgeCollider2D sword;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float health = 100;
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private int damage = 20;

    private bool dead = false;
    private float cooldownTimer = Mathf.Infinity;
    private float range = 1.5f;
    
    private EnemyMovement enemyMovement;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if (PlayerDetected())
        {
            if (cooldownTimer >= cooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        if (enemyMovement != null && !dead)
        {
            enemyMovement.enabled = !PlayerDetected();
        }
    }

    private bool PlayerDetected()
    {
        int direction = transform.localScale.x < 0 ? -1 : 1;
        RaycastHit2D hit = Physics2D.Raycast(bc.bounds.center, transform.right * direction ,range, playerLayer);

        if (hit.collider != null)
        {
            playerLife = hit.transform.GetComponentInChildren<PlayerLife>();
        }
        return hit.collider != null;
    }
    private void Die()
    {
        PuzzleManager.instance.EnemyDefeated();
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false;
        }
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        bc.enabled = false;
        sword.enabled = false;
        dead = true;
        Destroy(gameObject, 4f);
    }

    private void DamagePlayer()
    {
        if (PlayerDetected())
        {
            playerLife.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health);
        if (health <= 0)
        {
            Die();
        }
    }
}
