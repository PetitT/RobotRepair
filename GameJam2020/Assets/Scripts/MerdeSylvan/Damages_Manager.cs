using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damages_Manager : MonoBehaviour
{

    #region Variables

    public List<Damages_Zone> damagesZoneList;
    public event Action onDeath;
    public event Action onDamageTaken;

    private int punchNumber;

    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private Animator bodyMechaAnim;
    [SerializeField] private Animator canonMech;

    private Animation currentAnimation;

    public static Damages_Manager instance;
    #endregion
    #region OnCollision

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        punchNumber = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check what is the type of the enemy who is interracting with the mech. Then active a random damage zone of the enemy type.

        if (collision.gameObject.tag == "Enemy")
        {

            if (punchNumber == 0)
            {

                bodyMechaAnim.SetTrigger("PunchOne");
                canonMech.SetTrigger("CannonOne");
                punchNumber++;

                bodyMechaAnim.ResetTrigger("PunchTwo");

            }
            else if (punchNumber == 1)
            {

                bodyMechaAnim.SetTrigger("PunchTwo");
                canonMech.SetTrigger("CannonTwo");
                punchNumber--;

                bodyMechaAnim.ResetTrigger("PunchOne");

            }

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

    private void CheckList(InteractableObject interactableObject)
    {
        List<Damages_Zone> disabledZone = new List<Damages_Zone>();

        foreach (var item in damagesZoneList)
        {
            if (!item.isOn)
                disabledZone.Add(item);
        }

        if (disabledZone.Count == 2)
        {
            onDeath?.Invoke();
        }
        else
        {
            int objectToSet = UnityEngine.Random.Range(0, disabledZone.Count - 1);

            disabledZone[objectToSet].Activate(interactableObject);
        }

    }

    public void WalkSound()
    {

        SoundManager.instance.PlaySound(walkSound);

    }

    public void ExplosionSound()
    {

        SoundManager.instance.PlaySound(explosionSound);

    }

    public void PunchSound()
    {

        SoundManager.instance.PlaySound(punchSound);

    }

    #endregion


}
