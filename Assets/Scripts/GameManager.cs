using UnityEngine;
using System.IO;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI healthText;
    private PlayerData player;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene current, Scene next)
    {
        if (next.buildIndex != 0 && next.buildIndex != 5)
        {
            coinText = GameObject.Find("CoinHealthUI").transform.Find("CoinText").GetComponent<TextMeshProUGUI>();
            healthText = GameObject.Find("CoinHealthUI").transform.Find("HealthText").GetComponent<TextMeshProUGUI>();

            coinText.text = "" + player.Coins;
            healthText.text = "" + player.Health;
        }
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

        string playerData = File.ReadAllText(filePath);
        player = JsonConvert.DeserializeObject<PlayerData>(playerData);
        Debug.Log("File loaded.");
        SceneManager.LoadScene(player.CurrentLevel);
    }

    public void NewGame()
    {
        player = new PlayerData();
        SceneManager.LoadScene(player.CurrentLevel);
    }
    public void AddCoins(int amount)
    {
        player.Coins += amount;
        coinText.text = "" + player.Coins;
    }

    public bool ChangeHealth(float amount)
    {
        player.Health += amount;
        healthText.text = "" + player.Health;
        return player.Health <= 0;
    }

    public void SetCurrentLevel(int level)
    {
        player.CurrentLevel = level;
    }

    public float GetDamage()
    {
        return player.Damage;
    }
}
