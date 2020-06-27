using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            bool isHit = Physics.Raycast(ray, out hit);
            Transform objectHit;
            ValveController valveController = null;
            if (isHit)
            {
                
                objectHit = hit.transform;

                
                
                valveController = objectHit.GetComponent<ValveController>();

                if (valveController != null)
                {

                    float distance = Vector3.Distance(objectHit.position, transform.position);
                    if (distance < maxDistance)
                    {
                        valveController.active = !valveController.active;
                    }
                }
            }
        }

        
    }
}
