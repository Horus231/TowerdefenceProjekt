using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class CanonSpawner : MonoBehaviour
{
    public GameObject cannonPrefab;
    public int cannonCost = 50;
    public ARRaycastManager arRaycastManager;
    private bool isSpawningCannon = false;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isSpawningCannon == true)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();

            arRaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count > 0)
            {
                GameObject.Instantiate(cannonPrefab, touches[0].pose.position, touches[0].pose.rotation);
                isSpawningCannon = false;
                GoldManager.Instance.SpendGold(cannonCost);
            }
        }
    }

    public void EnterCannonSpawningMode()
    {
        if (GoldManager.Instance != null)
        {
            if (GoldManager.Instance.CanSpendGold(cannonCost))
            {
                isSpawningCannon = true;
            }
        }
    }
}
