using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiques : MonoBehaviour
{

    [SerializeField] AudioClip loop;

    private void Start()
    {

        StartCoroutine(LaunchLoop());

    }

    IEnumerator LaunchLoop()
    {

        yield return new WaitForSeconds(1f);

        SoundManager.instance.PlaySound(loop);

    }

}
