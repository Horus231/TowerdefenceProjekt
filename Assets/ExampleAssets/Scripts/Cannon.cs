using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;
    public int damage = 1;

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Target"))
            {
                LifeManager target = hitCollider.gameObject.GetComponent<LifeManager>();
                if (target != null)
                {
                    target.ReduceLife(damage);
                }
            }
        }
    }
}
