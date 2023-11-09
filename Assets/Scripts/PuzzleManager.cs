using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private GameObject level2_block;

    public void SolvePuzzle(int level, bool switched)
    {
        if (level == 2)
        {
            level2_block = GameObject.Find("Grass");
            level2_block.GetComponent<SpriteRenderer>().enabled = switched;
            level2_block.GetComponent<BoxCollider2D>().enabled = switched;
        }
    }
}
