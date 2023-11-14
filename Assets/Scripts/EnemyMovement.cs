using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform routeStart;
    [SerializeField] private Transform routeEnd;
    private Animator anim;

    private float speed = 2f;
    private Vector3 initScale;
    private bool movingLeft;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        initScale = transform.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("isRunning", false);
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= routeStart.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            if (transform.position.x <= routeEnd.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int direction)
    {
        anim.SetBool("isRunning", true);
        transform.localScale = new Vector3(Mathf.Abs(-initScale.x) * direction, initScale.y, initScale.z);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed, transform.position.y, transform.position.z);
    }
}
