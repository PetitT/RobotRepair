using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAddon2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            Inventory.instance.currentLootableObject2 = collision.GetComponent<LootablePile>().item;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
            Inventory.instance.currentLootableObject2 = InteractableObject.none;
        }
    }

}
