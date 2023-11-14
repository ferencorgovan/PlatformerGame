using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void UpdateHealthBar(int health)
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
        else
        {
            slider.value = health;
        }
    }
}
