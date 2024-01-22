using UnityEngine;
using TMPro; 

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public TextMeshProUGUI goldTextTMP;
    public TextMeshProUGUI healthTextTMP;
    private int health = 11;
    private int goldAmount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        UpdateGoldTextTMP();
    }

    private void UpdateGoldTextTMP()
    {
        goldTextTMP.text = "Gold: " + goldAmount.ToString();
    }

    public bool CanSpendGold(int amount)
    {
        return goldAmount >= amount;
    }

    public void SpendGold(int amount)
    {
        if (CanSpendGold(amount))
        {
            goldAmount -= amount;
            UpdateGoldTextTMP();
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
        health -= amount;
        if (alive())
        {
            UpdateHealthTextTMP(health);
        }
    }
}
