using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages_Zone : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField]
    GameObject Mecha;

    [SerializeField]
    SpriteRenderer ownSelf;

    public int typeOfDamage;

    #endregion
    #region Start

    private void Start()
    {

        Mecha.GetComponent<Damages_Manager>().damagesZoneList.Add(this);
        ownSelf.enabled = false;

    }

    #endregion
    #region Methods

    public override void ActiveAreaEffects()
    {
        FindObjectOfType<Inventory>().currentItem = InteractableObject.none;
        objectNeeded = InteractableObject.none;

        ownSelf.enabled = false;
        isOn = false;

    }

    public void Activate(InteractableObject interactableObject)
    {
        objectNeeded = interactableObject;

        ownSelf.enabled = true;

        if (objectNeeded == InteractableObject.electric)
        {

            Color newColor = new Color(0.8822017f, 1f, 0f);

            ownSelf.color = newColor;

        }
        else if(objectNeeded == InteractableObject.physical)
        {

            Color newColor = new Color(0.7254902f, 0f, 0.2806867f);

            ownSelf.color = newColor;

        }

        isOn = true;

    }

    #endregion

}
