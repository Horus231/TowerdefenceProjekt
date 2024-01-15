using UnityEngine;

public class ARTapToKill : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    LifeManager lifeManager = hit.collider.gameObject.GetComponent<LifeManager>();
                    if (lifeManager != null)
                    {
                        lifeManager.ReduceLife();
                    }
                }
            }
        }
    }
}
