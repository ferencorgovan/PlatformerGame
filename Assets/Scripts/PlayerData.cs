using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int health;
    private bool hasWeapon;
    private int coins;
    private int lastCompletedLevel;

    public PlayerData()
    {
        this.health = 100;
        this.hasWeapon = false;
        this.coins = 0;
        this.lastCompletedLevel = 0;
    }

    public int Health { get => health; set => health = value; }
    public bool HasWeapon { get => hasWeapon; set => hasWeapon = value; }
    public int Coins { get => coins; set => coins = value; }
    public int LastCompletedLevel { get => lastCompletedLevel; set => lastCompletedLevel = value; }
}
