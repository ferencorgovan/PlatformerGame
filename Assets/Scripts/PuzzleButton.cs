using UnityEngine;

public class PuzzleButton : MonoBehaviour, IInteractive
{
    [SerializeField] ButtonDirection direction;
    public void Interact()
    {
        PuzzleManager.instance.Level4ButtonPuzzle(direction);
    }

    public string InteractionPrompt()
    {
        return "[E] Press";
    }
}
