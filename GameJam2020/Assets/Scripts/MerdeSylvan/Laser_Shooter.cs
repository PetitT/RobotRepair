using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Shooter : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField] Transform Mecha;
    [SerializeField] Transform MechaCannon;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject ultraLaser;
    [SerializeField] AudioClip laserClip;

    private float ultraStart = 0f;
    public float ultraCooldown = 10f;

    public event Action onShoot;

    #endregion
    #region Start
    private void Start()
    {

        isOn = true;

    }
    #endregion
    #region Methods

    public override void ActiveAreaEffects1()
    {

        if (isOn && Inventory.instance.superPowerAmmo == false)
        {
           
            Pool.instance.GetItemFromPool(laser, Mecha.position);
            SoundManager.instance.PlaySound(laserClip);
            FindObjectOfType<Inventory>().currentItem1 = InteractableObject.none;

            onShoot?.Invoke();

        }

    }

    public override void ActiveAreaEffects2()
    {
        if (isOn && Inventory.instance.superPowerAmmo == false)
        {
            Pool.instance.GetItemFromPool(laser, Mecha.position);
            SoundManager.instance.PlaySound(laserClip);
            FindObjectOfType<Inventory>().currentItem2 = InteractableObject.none;

            onShoot?.Invoke();
        }

    }

    public override void ActiveAreaTogether()
    {

        if (isOn && Inventory.instance.superPowerAmmo == true && Time.time > ultraStart + ultraCooldown)
        {

            FindObjectOfType<Inventory>().currentItem1 = InteractableObject.none;
            FindObjectOfType<Inventory>().currentItem2 = InteractableObject.none;

            Mecha.GetComponent<Animator>().SetTrigger("FIRE");
            MechaCannon.GetComponent<Animator>().SetTrigger("FIRE");

            ultraStart = Time.time;


            Pool.instance.GetItemFromPool(ultraLaser, Mecha.position);

        }

    }

    #endregion

}
