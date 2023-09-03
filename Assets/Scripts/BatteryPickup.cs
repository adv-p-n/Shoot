using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float spotAngleIncrease = 50f;
    [SerializeField] float intensityIncrease = 4f;
    Lighting myLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myLight = other.GetComponentInChildren<Lighting>();
            myLight.IncreaseLightIntensity(intensityIncrease);
            myLight.IncreaseSpotAngle(spotAngleIncrease);
            gameObject.SetActive(false);
        }
    }
    
}
