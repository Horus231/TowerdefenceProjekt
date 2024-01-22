using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    public TextMeshProUGUI healthTextTMP;
    private int health = 11;

    void Awake()
    {
        if (Instance == null)
        {
            healthTextTMP.text = "Health: " + health;
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthTextTMP(int health)
    {
        healthTextTMP.text = "Health: " + health.ToString();
    }

    public void DeathMessage()
    {
        healthTextTMP.text = "Game Over";
    }

    public bool alive()
    {
        if (health <= 0)
        {
            DeathMessage();
            return false;
        } 
        return true;
    }

    public void takeDamage(int amount)
    {
        health = health - amount;
        if(alive())
        {
            UpdateHealthTextTMP(health);
        }
    }
}
