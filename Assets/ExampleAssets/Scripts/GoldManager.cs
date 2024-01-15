using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public TextMeshProUGUI goldTextTMP; // Reference to the TextMeshProUGUI that displays the gold amount
    // If you're using 3D/2D TextMeshPro, use 'public TextMeshPro goldTextTMP;' instead
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
}
