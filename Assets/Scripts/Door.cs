using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    SpriteRenderer[] wires;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        wires = GetComponentsInChildren<SpriteRenderer>();
    }
    public void Unlock()
    {
        anim.SetBool("open", true);
        foreach (SpriteRenderer wire in wires) 
        {
            wire.color = Color.green;
        }
    }

    public void Close()
    {
        anim.SetBool("open", false);
        foreach (SpriteRenderer wire in wires)
        {
            wire.color = Color.white;
        }
    }
}
