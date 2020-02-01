using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Shooter : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField] Transform Mecha;
    [SerializeField] GameObject laser;
    [SerializeField] AudioClip laserClip;


    public event Action onShoot;

    #endregion
    #region Start
    private void Start()
    {

        isOn = true;

    }
    #endregion
    #region

    public override void ActiveAreaEffects()
    {
        if(isOn)
        {
            Pool.instance.GetItemFromPool(laser, Mecha.position);
            SoundManager.instance.PlaySound(laserClip);
            FindObjectOfType<Inventory>().currentItem = InteractableObject.none;
            onShoot?.Invoke();
        }

    }

    #endregion

}
