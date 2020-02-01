using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InteractableObject currentItem = InteractableObject.none;

    public InteractableObject currentLootableObject;

    [SerializeField] private string grab;
    [SerializeField] private GameObject grabParticle;
    [SerializeField] private AudioClip grabSound;

    public static Inventory instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown(grab))
        {
            Debug.Log("hiku");
            currentItem = currentLootableObject;
            if(currentItem != InteractableObject.none)
            {

                SoundManager.instance.PlaySound(grabSound);

                Pool.instance.GetItemFromPool(grabParticle, transform.position);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LootablePile"))
        {
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

    public void SetCurrentItem(InteractableObject item)
    {
        currentItem = item;
    }
}

