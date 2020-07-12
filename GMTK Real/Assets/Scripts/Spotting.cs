using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spotting : MonoBehaviour
{
    public AudioSource _audioSource;
    public GameObject button;
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
        
        if (collision.gameObject.name == "Monster")
        {
            Debug.Log("MONSTER SPOTTED");
            PlayMusic();
            Instantiate(bloodBoom, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            
            
            button.SetActive(true);

            
            //toMenu();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
