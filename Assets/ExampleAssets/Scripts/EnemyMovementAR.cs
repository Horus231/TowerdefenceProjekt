using UnityEngine;

public class EnemyMovementAR : MonoBehaviour
{
    public Transform tower; // Assign the tower's transform in the Unity Editor
    public float speed = 2.0f; // Movement speed of the enemy

    void Update()
    {
        if (tower == null) return;

        // Calculate the direction to the tower
        Vector3 direction = (tower.position - transform.position).normalized;

        // Move the enemy towards the tower
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Make the enemy face the tower
        Vector3 lookDirection = new Vector3(tower.position.x, transform.position.y, tower.position.z);
        transform.LookAt(lookDirection);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy has collided with the tower
        if (collision.gameObject.transform == tower)
        {
            // Perform actions upon collision, like:
            // - Deal damage to the tower
            // - Destroy the enemy GameObject
            // - Trigger an explosion effect, etc.

            Destroy(gameObject); // Example action: destroy the enemy
        }
    }
}
