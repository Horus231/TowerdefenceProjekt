using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewegung : MonoBehaviour
{
     public Transform targetObject;  // Das Zielobjekt, dem das andere Objekt folgen soll
    public float movementSpeed = 5f; // Die Geschwindigkeit, mit der sich das Objekt bewegt
    public float rotationSpeed = 5f; // Die Geschwindigkeit, mit der sich das Objekt dreht

    void Update()
    {
        // Berechne die Richtung zum Zielobjekt
        Vector3 directionToTarget = targetObject.position - transform.position;

        // Bewege das Objekt zum Zielobjekt
        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, movementSpeed * Time.deltaTime);

        // Drehe das Objekt in Richtung des Zielobjekts
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Überprüfe, ob das Objekt das Zielobjekt erreicht hat
        if (Vector3.Distance(transform.position, targetObject.position) < 0.01f)
        {
            // Lösche das erste Objekt
            Destroy(gameObject);
        }
    }
}
