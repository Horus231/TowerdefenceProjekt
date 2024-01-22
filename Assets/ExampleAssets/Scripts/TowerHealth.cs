using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int health = 100;

    public void update()
    {
        if(health <= 0)
        {
            if (HealthManager.Instance != null)
            {
                HealthManager.Instance.DeathMessage();
            }
            Destroy(gameObject);
        }
    }

    public void takeDamage(int amount)
    {
        health = health - amount;
        if (HealthManager.Instance != null)    
        {
            HealthManager.Instance.UpdateHealthTextTMP(health);
        }
 
    }
}
