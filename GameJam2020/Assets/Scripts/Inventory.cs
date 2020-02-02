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
    [SerializeField] private GameObject scrap1, electric1, ammo1;
    [SerializeField] private GameObject scrap2, electric2, ammo2;

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
            currentItem1 = currentLootableObject1;

            switch (currentItem1)
            {
                case InteractableObject.none:
                    scrap1.SetActive(false);
                    electric1.SetActive(false);
                    ammo1.SetActive(false);
                    break;
                case InteractableObject.physical:
                    scrap1.SetActive(true);
                    electric1.SetActive(false);
                    ammo1.SetActive(false);
                    break;
                case InteractableObject.electric:
                    scrap1.SetActive(false);
                    electric1.SetActive(true);
                    ammo1.SetActive(false);
                    break;
                case InteractableObject.ammo:
                    scrap1.SetActive(false);
                    electric1.SetActive(false);
                    ammo1.SetActive(true);
                    break;
                default:
                    break;
            }

            if (currentItem1 != InteractableObject.none)
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
            currentItem2 = currentLootableObject2;

            switch (currentItem2)
            {
                case InteractableObject.none:
                    scrap2.SetActive(false);
                    electric2.SetActive(false);
                    ammo2.SetActive(false);
                    break;
                case InteractableObject.physical:
                    scrap2.SetActive(true);
                    electric2.SetActive(false);
                    ammo2.SetActive(false);
                    break;
                case InteractableObject.electric:
                    scrap2.SetActive(false);
                    electric2.SetActive(true);
                    ammo2.SetActive(false);
                    break;
                case InteractableObject.ammo:
                    scrap2.SetActive(false);
                    electric2.SetActive(false);
                    ammo2.SetActive(true);
                    break;
                default:
                    break;
            }

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

        switch (item)
        {
            case InteractableObject.none:
                scrap1.SetActive(false);
                electric1.SetActive(false);
                ammo1.SetActive(false);
                break;
            case InteractableObject.physical:
                scrap1.SetActive(true);
                electric1.SetActive(false);
                ammo1.SetActive(false);
                break;
            case InteractableObject.electric:
                scrap1.SetActive(false);
                electric1.SetActive(true);
                ammo1.SetActive(false);
                break;
            case InteractableObject.ammo:
                scrap1.SetActive(false);
                electric1.SetActive(false);
                ammo1.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void SetCurrentItem2(InteractableObject item)
    {
        currentItem2 = item;

        switch (item)
        {
            case InteractableObject.none:
                scrap2.SetActive(false);
                electric2.SetActive(false);
                ammo2.SetActive(false);
                break;
            case InteractableObject.physical:
                scrap2.SetActive(true);
                electric2.SetActive(false);
                ammo2.SetActive(false);
                break;
            case InteractableObject.electric:
                scrap2.SetActive(false);
                electric2.SetActive(true);
                ammo2.SetActive(false);
                break;
            case InteractableObject.ammo:
                scrap2.SetActive(false);
                electric2.SetActive(false);
                ammo2.SetActive(true);
                break;
            default:
                break;
        }
    }
}

