using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages_Zone : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField] private GameObject electricParticle, physicalParticle;
    [SerializeField] private GameObject niceParticle;
    [SerializeField] private AudioClip repairSound;

    #endregion
    #region Start

    private void Start()
    {
        sprite.enabled = false;
    }

    #endregion
    #region Methods

    public override void ActiveAreaEffects1()
    {
        Inventory.instance.SetCurrentItem1(InteractableObject.none);
        objectNeeded = InteractableObject.none;
        Pool.instance.GetItemFromPool(niceParticle, transform.position);

        SoundManager.instance.PlaySound(repairSound);

        sprite.enabled = false;
        isOn = false;
    }

    public override void ActiveAreaEffects2()
    {
        Inventory.instance.SetCurrentItem2(InteractableObject.none);
        objectNeeded = InteractableObject.none;
        Pool.instance.GetItemFromPool(niceParticle, transform.position);

        SoundManager.instance.PlaySound(repairSound);

        sprite.enabled = false;
        isOn = false;
    }

    public override void ActiveAreaTogether()
    {

        Debug.Log("Nothing for now here");

    }

    public void Activate(InteractableObject interactableObject)
    {
        objectNeeded = interactableObject;

        sprite.enabled = true;

        if (objectNeeded == InteractableObject.electric)
        {

            Pool.instance.GetItemFromPool(electricParticle, transform.position);

        }
        else if(objectNeeded == InteractableObject.physical)
        {

            Pool.instance.GetItemFromPool(physicalParticle, transform.position);

        }

        isOn = true;

    }

    #endregion

}
