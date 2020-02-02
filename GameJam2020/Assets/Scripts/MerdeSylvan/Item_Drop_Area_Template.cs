using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Drop_Area_Template : MonoBehaviour
{

    #region Variables

    public InteractableObject objectNeeded;
    public bool isOn = false;
    private bool playerOneHere;
    private bool playerTwoHere;
    [SerializeField] SpriteRenderer aura;

    #endregion
    #region OnCollision

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player1" && isOn)
        {
            if (aura != null)
                aura.enabled = true;

            playerOneHere = true;

            if (Inventory.instance.currentItem1 == objectNeeded)
            {

                ActiveAreaEffects1();

            }

        }

        if (collision.gameObject.tag == "Player2" && isOn)
        {
            if (aura != null)
                aura.enabled = true;

            playerTwoHere = true;

            if (Inventory.instance.currentItem2 == objectNeeded)
            {

                ActiveAreaEffects2();

            }

        }

        if(playerOneHere == true && playerTwoHere == true)
        {

            ActiveAreaTogether();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (aura != null)
            aura.enabled = false;

        if (collision.gameObject.tag == "Player1")
        {

            playerOneHere = false;

        }

        if (collision.gameObject.tag == "Player2")
        {

            playerTwoHere = false;

        }

    }

    #endregion
    #region Methods

    public abstract void ActiveAreaEffects1();
    public abstract void ActiveAreaEffects2();
    public abstract void ActiveAreaTogether();

    #endregion

}
