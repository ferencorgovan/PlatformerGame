using UnityEngine;
using System.IO;
using TMPro;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private TextMeshProUGUI HPText;
    private PlayerData player;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        //string playerData = JsonUtility.ToJson(player);
        string playerData = JsonConvert.SerializeObject(player);

        Debug.Log(filePath);
        File.WriteAllText(filePath, playerData);
        Debug.Log("File saved.");
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        if (File.Exists(filePath))
        {
            string playerData = File.ReadAllText(filePath);

            //player = JsonUtility.FromJson<PlayerData>(playerData);
            player = JsonConvert.DeserializeObject<PlayerData>(playerData);
            Debug.Log("File loaded.");
            coinCountText.text = "" + player.Coins;
            HPText.text = "" + player.Health;

        }
        else
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        player = new PlayerData();
    }
    public void AddCoins(int amount)
    {
        player.Coins += amount;
        coinCountText.text = "" + player.Coins;
    }

    public bool ChangeHealth(int amount)
    {
        player.Health += amount;
        HPText.text = "" + player.Health;
        return player.Health <= 0;
    }

    public void ResetHealth()
    {
        player.Health = 100;
        HPText.text = "" + player.Health;
    }

    public void SetCurrentLevel(int level)
    {
        player.CurrentLevel = level;
    }
}
