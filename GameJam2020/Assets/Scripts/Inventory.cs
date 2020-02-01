using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InteractableObject currentItem = InteractableObject.none;

    public InteractableObject currentLootableObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentItem = currentLootableObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            //if (Input.GetKeyDown(KeyCode.F) && !isHolding)
            //{
            //    InteractableObject itemToLoot = collision.GetComponent<LootablePile>().item;
            //    Debug.Log("Button pressed");
            //    if (itemToLoot == InteractableObject.none)
            //    {
            //        Debug.Log("TOPKEK C IMPOSSIBLE");
            //    }
            //    else
            //    {
            //        currentItem = itemToLoot;
            //        isHolding = true;
            //        Debug.Log(currentItem);
            //    }

            //}

            currentLootableObject = collision.GetComponent<LootablePile>().item;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            currentLootableObject = InteractableObject.none;
        }
    }
}

