using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class spawnen : MonoBehaviour
{
    public GameObject towerPrefab;   // Turm-Objekt-Prefab
    public GameObject portalPrefab; // Portal-Objekt-Prefab
    public TMP_Text nachricht; 
    public ARRaycastManager arRaycastManager;

    private bool tower = false;
    private bool portal = false;

    void Start()
    {
        nachricht = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began && tower==false)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();

            arRaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if(touches.Count > 0)
            {
                GameObject.Instantiate(towerPrefab, touches[0].pose.position, touches[0].pose.rotation);
                tower=true;
                nachricht.text= "Sie können nun das Portal platzieren";
            }
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began && tower==true && portal == false){

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            arRaycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if(hits.Count > 0)
            {
                GameObject.Instantiate(portalPrefab, hits[0].pose.position, hits[0].pose.rotation);
                portal=true;
                nachricht.text="";
            }
        }
    }

    

    
}