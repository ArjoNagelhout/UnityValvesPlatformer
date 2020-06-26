using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour
{

    public Transform valveTransform;
    private float currentRotation;
    public float inactiveRotation;
    public float activeRotation;

    public float minDifference;

    public GameObject activeIndicator;

    public float rotationSpeed;

    private float targetRotation;

    private bool tempValue;

    public bool active {
        get {
            return m_active;
        }
        set {
            tempValue = value;

            
            if (value == true) {
                // Gets set to active
                targetRotation = activeRotation;
            } else {
                targetRotation = inactiveRotation;
            }

        }
    }

    private bool m_active;



    // Start is called before the first frame update
    void Start()
    {
        active = active;
    }

    // Update is called once per frame
    void Update()
    {

        // Update the rotation

        currentRotation = Mathf.Lerp(currentRotation, targetRotation, rotationSpeed);

        if (Mathf.Abs(currentRotation-targetRotation)<minDifference)
        {
            m_active = tempValue;
            activeIndicator.SetActive(tempValue);
        }

        valveTransform.localRotation = Quaternion.Euler(currentRotation, 0, 0);

	}
}
