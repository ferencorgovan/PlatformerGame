using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void UpdateHealthBar(float health)
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
