using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
 
    private GameObject level2_block;
    public int enemiesDefeated;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        enemiesDefeated = 0;
    }
    public void SolvePuzzle(int level, bool switched)
    {
        switch (level)
        {
            case 2:
                Level2SwitchPuzzle(switched);
                break;
            case 3:
                break;
        }
    }
    private void Level2SwitchPuzzle(bool switched)
    {
        level2_block = GameObject.Find("SwordPuzzleBlock");
        level2_block.GetComponent<SpriteRenderer>().enabled = switched;
        level2_block.GetComponent<BoxCollider2D>().enabled = switched;
    }

    private void Level2PlatformPuzzle()
    {
        GameObject.Find("EnemyPuzzleBlock").GetComponent<Animator>().SetTrigger("up");
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated == 3)
        {
            Level2PlatformPuzzle();
        }
    }
}
