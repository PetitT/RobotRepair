using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{

    [SerializeField] private AudioClip walk;

    private float startWalking = 0f;
    public float coolDownWalking = 10f;

    public bool isWalking = true;

    #region Updates

    private void Update()
    {

        if (isWalking == true && Time.time > startWalking + coolDownWalking)
        {

            SoundManager.instance.PlaySound(walk);
            startWalking = Time.time;

        }

    }

    #endregion

}
