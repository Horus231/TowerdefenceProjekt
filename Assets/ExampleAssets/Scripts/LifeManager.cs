using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int lifeCount = 3;  // Number of lives
    public int goldValue = 10; // Gold value received when object is destroyed

    public void ReduceLife()
    {
        lifeCount--;
        if (lifeCount <= 0)
        {
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(goldValue);
            }
            Destroy(gameObject);
        }
    }
}
