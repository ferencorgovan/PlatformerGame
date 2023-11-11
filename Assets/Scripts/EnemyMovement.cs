using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform routeStart;
    [SerializeField] private Transform routeEnd;
    [SerializeField] private Transform enemy;
    [SerializeField] private Animator anim;

    private float speed = 2f;
    private Vector3 initScale;
    private bool movingLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("isRunning", false);
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= routeStart.position.x)
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
            if (enemy.position.x <= routeEnd.position.x)
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
        enemy.localScale = new Vector3(Mathf.Abs(-initScale.x) * direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }
}
