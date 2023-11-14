using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private PlayerLife playerLife;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private HealthBar healthBar;

    [SerializeField] private EdgeCollider2D sword;
    [SerializeField] private LayerMask playerLayer;
    

    private bool dead = false;
    private float cooldown = 1.5f;
    private float cooldownTimer = Mathf.Infinity;
    private float range = 2f;
    private int damage = 20;
    
    private EnemyMovement enemyMovement;
    
    void Awake()
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
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center + transform.right * range * transform.localScale.x * 0.4f,
            new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerLife = hit.transform.GetComponentInChildren<PlayerLife>();
        }
        return hit.collider != null;
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * 0.4f,
            new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z));
    }
    */
    private void Die()
    {
        PuzzleManager.instance.EnemyDefeated();
        enemyMovement.enabled = false;
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

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health);
        if (health <= 0)
        {
            Die();
        }
    }
}
