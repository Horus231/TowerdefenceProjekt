using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterleben : MonoBehaviour
{
    public GameObject arCamera;
    
    public int hp;

    RaycastHit hit;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                if(hit.transform.tag == "Monster")
                {
                    
                    hp=hp -1;
                    if (hp==0){
                        Destroy(hit.transform.gameObject);
                        GoldundHP.gold = GoldundHP.gold + 5;
                    }
                    
                }
            }
        }
    }

}
