using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float displayTime = 0.3f;
    [SerializeField] Canvas damageDisplayCanvas;
    void Start()
    {
        damageDisplayCanvas.enabled = false;        
    }

    public void DisplayDamageCanvas()
    {
        StartCoroutine(ShowCanvas());
    }
    IEnumerator ShowCanvas()
    {
        damageDisplayCanvas.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageDisplayCanvas.enabled = false;
    }
}
