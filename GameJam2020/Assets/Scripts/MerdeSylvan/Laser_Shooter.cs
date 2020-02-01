using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Shooter : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField]
    Transform Mecha;
    [SerializeField]
    GameObject laser;

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
            // Need to see the good quaternion in Unity, can't find the right parameter only in script...
            Pool.instance.GetItemFromPool(laser, Mecha.position);

            // need a timer who unable the usage of the laser shooter for a while.

            FindObjectOfType<Inventory>().currentItem = InteractableObject.none;

            onShoot?.Invoke();
        }

    }

    #endregion

}
