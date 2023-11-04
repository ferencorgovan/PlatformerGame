using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] GameObject player;


    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("MapBound"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void RespawnPlayer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        player.transform.position = startPos;
        anim.SetTrigger("respawned");
        
    }
}
