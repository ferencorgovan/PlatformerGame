using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractive
{
    public bool switched = false;
    [SerializeField] private Sprite leverOn;
    [SerializeField] private Sprite leverOff;

    public int levelNumber;
    public void Interact()
    {
        switched = !switched;
        GetComponent<SpriteRenderer>().sprite = switched ? leverOn : leverOff;

        PuzzleManager.instance.SolvePuzzle(levelNumber, switched);
    }
}
