using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAndMove : MonoBehaviour
{
    public GameObject targetObject;         // The target object to move towards
    public GameObject transformedObject;    // The object to transform into
    public float movementSpeed = 5f;        // The speed at which the object moves

    private bool isTransformed = false;     // Flag to track if the object has transformed

    void Update()
    {
        if (!isTransformed)
        {
            // If the object hasn't transformed yet, move towards the target object
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate the direction from this object to the target object
        Vector3 directionToTarget = targetObject.transform.position - transform.position;

        // Normalize the direction to get a unit vector
        Vector3 normalizedDirection = directionToTarget.normalized;

        // Move the object towards the target
        transform.Translate(normalizedDirection * movementSpeed * Time.deltaTime);

        // Check if the object is close enough to the target to trigger the transformation
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);
        if (distanceToTarget < 0.5f)
        {
            // Destroy the moving object upon collision
            Destroy(gameObject);

            // Transform the object into the specified transformed object
            TransformIntoTransformedObject();
        }
    }

    void TransformIntoTransformedObject()
    {
        // Set the flag to indicate that the object has transformed
        isTransformed = true;

        // Enable and position the transformed object at the target position
        transformedObject.SetActive(true);
        transformedObject.transform.position = targetObject.transform.position;
    }
}