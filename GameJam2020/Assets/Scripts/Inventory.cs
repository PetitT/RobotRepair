using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InteractableObject currentItem1 = InteractableObject.none;
    public InteractableObject currentItem2 = InteractableObject.none;

    public InteractableObject currentLootableObject1;
    public InteractableObject currentLootableObject2;

    public bool superPowerAmmo;

    [SerializeField] private string grab1;
    [SerializeField] private string grab2;
    [SerializeField] private GameObject grabParticle;
    [SerializeField] private AudioClip grabSound;
    [SerializeField] private SpriteRenderer superAmmoSpriteInfo;

    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;

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
        if (Input.GetButtonDown(grab1))
        {
            Debug.Log("hiku");
            currentItem1 = currentLootableObject1;
            if(currentItem1 != InteractableObject.none)
            {

                SoundManager.instance.PlaySound(grabSound);

                Pool.instance.GetItemFromPool(grabParticle, Player1.transform.position);

            }
        }

        if(currentItem1 == currentItem2 && currentItem1 == InteractableObject.ammo)
        {

            superPowerAmmo = true;
            superAmmoSpriteInfo.enabled = true;

        }
        else
        {

            superPowerAmmo = false;
            superAmmoSpriteInfo.enabled = false;

        }

        if (Input.GetButtonDown(grab2))
        {
            Debug.Log("hiku");
            currentItem2 = currentLootableObject2;
            if (currentItem2 != InteractableObject.none)
            {

                SoundManager.instance.PlaySound(grabSound);

                Pool.instance.GetItemFromPool(grabParticle, Player2.transform.position);

            }
        }

    }

    public void SetCurrentItem1(InteractableObject item)
    {
        currentItem1 = item;
    }

    public void SetCurrentItem2(InteractableObject item)
    {
        currentItem2 = item;
    }

}

