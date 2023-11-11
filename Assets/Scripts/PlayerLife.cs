using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] EdgeCollider2D sword;
    [SerializeField] GameObject player;

    Vector2 startPos;
    void Start()
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

    public void TakeDamage(int damage)
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
        player.transform.position = startPos;
        bc.enabled = true;
        GameManager.instance.ResetHealth();
        anim.SetTrigger("respawned");
    }
}
