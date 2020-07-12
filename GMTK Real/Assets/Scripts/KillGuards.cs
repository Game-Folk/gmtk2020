using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGuards : MonoBehaviour
{
    public AudioSource _audioSource;
    public GameObject bloodBoom;

    public void PlayMusic()
    {
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Guardbutt")
        {
            PlayMusic();
            Instantiate(bloodBoom, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
