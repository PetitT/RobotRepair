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

    public override void ActiveAreaEffects()
    {
        Inventory.instance.SetCurrentItem(InteractableObject.none);
        objectNeeded = InteractableObject.none;
        Pool.instance.GetItemFromPool(niceParticle, transform.position);

        SoundManager.instance.PlaySound(repairSound);

        sprite.enabled = false;
        isOn = false;
    }

    public void Activate(InteractableObject interactableObject)
    {
        objectNeeded = interactableObject;

        sprite.enabled = true;

        if (objectNeeded == InteractableObject.electric)
        {

            Color newColor = new Color(0.8822017f, 1f, 0f);

            sprite.color = newColor;

            Pool.instance.GetItemFromPool(electricParticle, transform.position);
        }
        else if(objectNeeded == InteractableObject.physical)
        {

            Color newColor = new Color(0.7254902f, 0f, 0.2806867f);

            sprite.color = newColor;

            Pool.instance.GetItemFromPool(physicalParticle, transform.position);

        }

        isOn = true;

    }

    #endregion

}
