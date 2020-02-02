using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAddOn1 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            Inventory.instance.currentLootableObject1 = collision.GetComponent<LootablePile>().item;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            Inventory.instance.currentLootableObject1 = InteractableObject.none;
        }
    }

}
