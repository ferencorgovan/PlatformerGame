using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractive
{
    private bool open = false;
    [SerializeField] private GameObject weapon;
    [SerializeField] private ContentType contentType;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator content_anim;
    private SpriteRenderer chest_content;
    private void Start()
    {
        chest_content = GetComponentInChildren<SpriteRenderer>();
    }
    public void Interact()
    {
        if(!open)
        {
            open = true;
            anim.SetTrigger("open");
            AquireContent();
        }
    }

    private void AquireContent()
    {
        content_anim.SetTrigger("aquire");
        switch (contentType)
        {
            case ContentType.Sword:
                StartCoroutine(AquireSword());
                break;
            default:
                break;
        }
    }

    private IEnumerator AquireSword()
    {
        yield return new WaitForSeconds(4f);
        weapon.SetActive(true);
    }
}
