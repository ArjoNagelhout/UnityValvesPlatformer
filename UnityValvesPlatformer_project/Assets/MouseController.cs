using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
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
                    valveController.active = !valveController.active;
                }
            }
        }

        
    }
}
