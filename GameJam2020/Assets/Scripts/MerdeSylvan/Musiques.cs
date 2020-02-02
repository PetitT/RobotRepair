using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiques : MonoBehaviour
{

    [SerializeField] AudioClip intro;
    [SerializeField] AudioClip loop;

    private void Start()
    {

        SoundManager.instance.PlaySound(loop);

    }

}
