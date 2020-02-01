using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages_Manager : MonoBehaviour
{

    #region Variables

    public List<Damages_Zone> damagesZoneList = new List<Damages_Zone>();
    public event Action onDeath;
    public event Action onDamageTaken;

    public static Damages_Manager instance;
    #endregion
    #region OnCollision

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check what is the type of the enemy who is interracting with the mech. Then active a random damage zone of the enemy type.

        if (collision.gameObject.tag == "Enemy")
        {

            InteractableObject enemyTypeVar = collision.gameObject.GetComponent<EnemyIdentifyer>().ID;

            switch (enemyTypeVar)
            {
                case InteractableObject.none:

                    Debug.Log("Error, Invalid object type");

                    break;
                case InteractableObject.physical:

                    CheckList(enemyTypeVar);
                    onDamageTaken?.Invoke();

                    break;
                case InteractableObject.electric:

                    CheckList(enemyTypeVar);
                    onDamageTaken?.Invoke();

                    break;
                case InteractableObject.ammo:

                    Debug.Log("Error, Invalid object type");

                    break;
                default:
                    break;
            }

        }

    }

    #endregion
    #region Methods

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void CheckList(InteractableObject interactableObject)
    {

        // Method to randomly find a Damage zone object who is disable, and active it.

        List<Damages_Zone> disabledZone = new List<Damages_Zone>();

        for (int i = 0; i < damagesZoneList.Count; i++)
        {

            if (damagesZoneList[i].isOn == false)
            {

                disabledZone.Add(damagesZoneList[i]);

            }

            if (disabledZone.Count == 0)
            {
                onDeath?.Invoke();
            }

        }

        int objectToSet = UnityEngine.Random.Range(0, disabledZone.Count -1);

        disabledZone[objectToSet].Activate(interactableObject);
    }
    #endregion


}
