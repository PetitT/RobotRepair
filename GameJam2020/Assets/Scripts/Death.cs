using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    // Utilité : Toutes les animations, sons, ect, s'activeront quand l'event Died se déclenchera

    public event Action Died;

    // Cette classe sert juste d'exmple 
    // Elle devra s'abonner au "Damage Manager" et Invoke l'event quand les dégâts atteindront leur maximum


    private void Start()
    {
        Damages_Manager.instance.onDeath += DeathHandler;
    }

    private void OnDisable()
    {
        Damages_Manager.instance.onDeath -= DeathHandler;
    }

    private void OnEnable()
    {
        Damages_Manager.instance.onDeath += DeathHandler;

    }

    private void DeathHandler()
    {

        Died?.Invoke();
        Damages_Manager.instance.onDeath -= DeathHandler;
    }
}
