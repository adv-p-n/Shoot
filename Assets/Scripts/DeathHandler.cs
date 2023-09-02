using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    StarterAssets.StarterAssetsInputs starterAssetsInputs;
    GameObject player;
    WeaponSwitcher weaponSwitcher;
    WeaponZoom weaponZoom;

    void Start()
    {
        gameOverCanvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        starterAssetsInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
        weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        weaponZoom = FindObjectOfType<WeaponZoom>();
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        weaponSwitcher.enabled = false;
        weaponZoom.enabled = false;
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
