using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Drop_Area_Template : MonoBehaviour
{

    #region Variables

    public InteractableObject objectNeeded;
    public bool isOn = false;
    [SerializeField] SpriteRenderer aura;

    #endregion
    #region OnCollision

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && isOn)
        {
            if (aura != null)
                aura.enabled = true;

            if (collision.gameObject.GetComponent<Inventory>().currentItem == objectNeeded)
            {

                ActiveAreaEffects();

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (aura != null)
            aura.enabled = false;

    }

    #endregion
    #region Methods

    public abstract void ActiveAreaEffects();

    #endregion

}
