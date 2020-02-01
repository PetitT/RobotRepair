using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Drop_Area_Template : MonoBehaviour
{

    #region Variables

    public InteractableObject objectNeeded;
    public bool isOn = false;

    #endregion
    #region OnCollision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && isOn)
        {

            if(collision.gameObject.GetComponent<Inventory>().currentItem == objectNeeded)
            {

                ActiveAreaEffects();

            }

        }

    }

    #endregion
    #region Methods

    public abstract void ActiveAreaEffects();

    #endregion

}
