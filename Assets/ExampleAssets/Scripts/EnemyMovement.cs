using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 10;

    private GameObject tower;
    private bool isMoving = true;

    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");
        if (tower == null)
        {
            Debug.LogError("Tower object not found in the scene!");
            isMoving = false;
        }
    }

    void Update()
    {
        if (isMoving && tower != null)
        {
            MoveTowardsTower();
        }
    }

    private void MoveTowardsTower()
    {
        Vector3 direction = (tower.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider dest)
    {
        if (dest.gameObject.CompareTag("Tower"))
        {
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.takeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
