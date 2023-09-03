using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    [SerializeField] float spotAngleDecreaseRate = 1.5f;
    [SerializeField] float intensityDecreaseRate = 0.1f;
    [SerializeField] float minimumAngle = 30f;

    Light myLight;

    void Start()
    {
        myLight= GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) { return; }
        myLight.spotAngle -= spotAngleDecreaseRate*Time.deltaTime;

    }

    void DecreaseLightIntensity()
    {
        myLight.intensity -= intensityDecreaseRate*Time.deltaTime;
    }
    public void IncreaseSpotAngle(float angleAmount)
    {
        myLight.spotAngle = angleAmount;
    }
    public void IncreaseLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }
}
