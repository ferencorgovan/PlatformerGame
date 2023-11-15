using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    private void Update()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "PlayerData.json")))
        {
            continueButton.enabled = true;
        }
        else
        {
            continueButton.enabled = false;
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
