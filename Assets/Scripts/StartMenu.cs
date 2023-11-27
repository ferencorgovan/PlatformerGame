using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Update()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "PlayerData.json")))
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }
    public void Continue()
    {
        GameManager.instance.LoadGame();
    }
    public void NewGame()
    {
        GameManager.instance.NewGame();
    }
}
