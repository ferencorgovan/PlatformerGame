using TMPro;
using UnityEngine;

public class help : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputPrompt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inputPrompt.text = "[WASD] Move [Shift] Sprint [LeftClick] Attack";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputPrompt.text = "";
    }
}
