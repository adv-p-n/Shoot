using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{   
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomOutFov = 40f;
    [SerializeField] float zoomInSensitivity = 5f;
    [SerializeField] float zoomOutSensitivity = 1.0f;

    CinemachineVirtualCamera playerCamera;
    FirstPersonController fpController;

    bool zoomedIn = false;
    private void OnDisable()
    {
        WeaponZoomOut();
    }

    void Start()
    {
        playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
        fpController = FindObjectOfType<FirstPersonController>();
    }

     void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            WeaponZoomIn();
        }
        else if(Input.GetMouseButtonUp(1))
        {
            WeaponZoomOut();
        }
    }

     void WeaponZoomIn()
    {
        if (playerCamera == null && zoomedIn) { return; }
        playerCamera.m_Lens.FieldOfView = zoomInFOV;
        fpController.RotationSpeed = zoomInSensitivity;
        zoomedIn= true;
        
    }
    void WeaponZoomOut()
    {
        if (playerCamera == null && !zoomedIn) { return; }
        playerCamera.m_Lens.FieldOfView = zoomOutFov;
        fpController.RotationSpeed = zoomOutSensitivity;
        zoomedIn = false;
    }

}
