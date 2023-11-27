using UnityEngine;

public class Laser : MonoBehaviour, IInteractive
{
    private LaserEnable laserEnable;
    private PlayerMovement playerMovement;
    public void Interact()
    {
        laserEnable = GetComponentInChildren<LaserEnable>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        laserEnable.enabled = !laserEnable.enabled;
        playerMovement.enabled = !playerMovement.enabled;
    }

    public string InteractionPrompt()
    {
        return "[E] Use/Exit  [Up/Down Arrow] Move";
    }
}
