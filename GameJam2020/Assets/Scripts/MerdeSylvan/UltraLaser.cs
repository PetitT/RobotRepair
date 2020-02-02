using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraLaser : MonoBehaviour
{

    #region Variables
    public float lifeTime;

    [SerializeField] private AudioClip laserXplode;
    [SerializeField] private AudioClip ultraLaser;

    #endregion
    #region Updates

    private void Update()
    {

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            //gameObject.SetActive(false);
            Destroy(this.gameObject);

    }

    #endregion
    #region OnCollision

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            SoundManager.instance.PlaySound(laserXplode);

        }

    }
    #endregion

    public void UltraSound()
    {

        SoundManager.instance.PlaySound(ultraLaser);

    }

}
