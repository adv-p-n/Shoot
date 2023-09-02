using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] slots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammotype;
        public int ammoAmount = 5;
    }
    public int GetAmmoAmount(AmmoType ammoType)
    {
        AmmoSlot myslot = GetAmmoSlot(ammoType);
        return myslot.ammoAmount;
    }
    public void ReduceAmmoAmount(AmmoType ammoType)
    {
        AmmoSlot myslot = GetAmmoSlot(ammoType);
        myslot.ammoAmount--;
    }
    public void IncreaseAmmoAmount(AmmoType ammoType,int ammoAmount)
    {
        AmmoSlot myslot = GetAmmoSlot(ammoType);
        myslot.ammoAmount += ammoAmount;
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in slots)
        {
            if(slot.ammotype == ammoType)
            {
                return slot;
            }
            
        }
        return null;
    }
}
