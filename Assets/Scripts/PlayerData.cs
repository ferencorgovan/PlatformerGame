[System.Serializable]
public class PlayerData
{
    private float health;
    private bool hasWeapon;
    private int coins;
    private int currentLevel;
    private float damage;
    public PlayerData()
    {
        this.health = 100;
        this.hasWeapon = false;
        this.coins = 0;
        this.currentLevel = 1;
        this.damage = 30;
    }
    public float Health 
    { 
        get => health;
        set
        {
            if (value > 100)
            {
                health = 100;
            }
            else if (value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }
        }
    }
    public bool HasWeapon { get => hasWeapon; set => hasWeapon = value; }
    public int Coins 
    {
        get => coins; 
        set
        {
            if (value < 0)
            {
                coins = 0;
            }
            else
            {
                coins = value;
            }
        }
    }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public float Damage { get => damage; set => damage = value; }
}
