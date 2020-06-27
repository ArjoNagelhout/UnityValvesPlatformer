using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeWindowController : MonoBehaviour
{
    public float minFill;
    public float maxFill;

    public Renderer liquidRenderer;

    public ValvesController valvesController;
    public ValveController valveController;

    private float targetPercentage;

    private float currentPercentage;
    public float changeSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (valveController.active)
        {
            targetPercentage = valvesController.currentPercentage;
        } else
        {
            targetPercentage = 0f;
        }
        //Debug.Log(displayPercentage);

        currentPercentage = Mathf.Lerp(currentPercentage, targetPercentage, changeSpeed);

        float actualFill = Remap(currentPercentage, 0f, 1f, minFill, maxFill);
        liquidRenderer.material.SetFloat("_FillAmount", actualFill);
        //Debug.Log(liquidRenderer.material.GetFloat("_FillAmount"));
    }

    private float Remap(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}