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
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        string playerData = JsonConvert.SerializeObject(player);

        File.WriteAllText(filePath, playerData);
        Debug.Log("File saved.");
    }

    public void LoadGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        if (File.Exists(filePath))
        {
            string playerData = File.ReadAllText(filePath);
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

    public void SetCurrentLevel(int level)
    {
        player.CurrentLevel = level;
    }

    public int GetDamage()
    {
        return player.Damage;
    }
}
