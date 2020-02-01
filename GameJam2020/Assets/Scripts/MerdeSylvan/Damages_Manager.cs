﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages_Manager : MonoBehaviour
{

    #region Variables

    public List<Damages_Zone> damagesZoneList = new List<Damages_Zone>();
    public event Action onDeath;

    bool gameOver;

    #endregion
    #region Start

    private void Start()
    {

        gameOver = false;

    }

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

                    break;
                case InteractableObject.electric:

                    CheckList(enemyTypeVar);

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
                Debug.Log("Dead");
            }
            else
            {
                int objectToSet = UnityEngine.Random.Range(0, disabledZone.Count);

                disabledZone[objectToSet].Activate(interactableObject);
            }

        }


    }
    #endregion


}
