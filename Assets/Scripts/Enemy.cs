using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerLife playerLife;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private EdgeCollider2D sword;
    [SerializeField] private LayerMask playerLayer;
    
    private float cooldown = 2f;
    private float cooldownTimer = Mathf.Infinity;
    private float range = 2f;
    private int damage = 20;
    
    private EnemyMovement enemyMovement;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
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

        if (enemyMovement != null)
        {
            enemyMovement.enabled = !PlayerDetected();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Die();
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
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * 0.4f,
            new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z));
    }
    
    
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        bc.enabled = false;
        sword.enabled = false;
        Destroy(gameObject, 4f);
    }

    private void DamagePlayer()
    {
        if (PlayerDetected())
        {
            playerLife.TakeDamage(damage);
        }
    }
}
