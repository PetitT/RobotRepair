using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages_Zone : Item_Drop_Area_Template
{

    #region Variables

    [SerializeField]
    GameObject Mecha;

    #endregion
    #region Start

    private void Start()
    {

        Mecha.GetComponent<Damages_Manager>().damagesZoneList.Add(this);

    }

    #endregion
    #region Methods

    public override void ActiveAreaEffects()
    {
        FindObjectOfType<Inventory>().currentItem = InteractableObject.none;
        objectNeeded = InteractableObject.none;
        // var who say to the Script made by Nicolas to remove the object he is holding
        // disable the animator(hide the gameobject)
        isOn = false;

    }

    public void Activate(InteractableObject interactableObject)
    {
        objectNeeded = interactableObject;
        isOn = true;
        // animator fonction to show the zone

    }

    #endregion

}
