using System.Collections;
using UnityEngine;
public class Chest : MonoBehaviour, IInteractive
{
    private bool open = false;
    [SerializeField] private GameObject weapon;
    [SerializeField] private ContentType contentType;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator content_anim;
    [SerializeField] private int content_quantity;
    public void Interact()
    {
        if(!open)
        {
            open = true;
            anim.SetTrigger("open");
            AquireContent();
        }
    }
    public string InteractionPrompt()
    {
        return "[E] Open";
    }
    private void AquireContent()
    {
        content_anim.SetTrigger("aquire");
        switch (contentType)
        {
            case ContentType.Sword:
                StartCoroutine(AquireSword());
                break;
            case ContentType.Coin:
                GameManager.instance.AddCoins(content_quantity);
                break;
            case ContentType.Health:
                GameManager.instance.ChangeHealth(content_quantity);
                break;
            default:
                break;
        }
    }
    private IEnumerator AquireSword()
    {
        yield return new WaitForSeconds(2f);
        weapon.SetActive(true);
    }
}
