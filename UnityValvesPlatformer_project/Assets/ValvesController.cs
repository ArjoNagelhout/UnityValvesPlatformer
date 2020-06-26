using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvesController : MonoBehaviour
{
    public List<ValveController> valveControllers;

    [System.NonSerialized]
    public bool active;

    public float currentPercentage;

    // Update is called once per frame
    void Update()
    {
        int amountInactive = valveControllers.Count+1;
        foreach (ValveController valveController in valveControllers)
        {
            if (valveController.active == true)
            {
                amountInactive -= 1;
            }
        }
        currentPercentage = amountInactive / (float)valveControllers.Count;
    }
}
