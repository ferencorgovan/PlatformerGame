using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int health;
    private bool hasWeapon;
    private int coins;
    private int currentLevel;
    private int damage;

    public PlayerData()
    {
        this.health = 100;
        this.hasWeapon = false;
        this.coins = 0;
        this.currentLevel = 0;
        this.damage = 30;
    }

    public int Health 
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
    public int Coins { get => coins; set => coins = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int Damage { get => damage; set => damage = value; }
}
