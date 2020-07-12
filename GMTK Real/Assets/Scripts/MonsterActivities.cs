using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActivities : MonoBehaviour
{
    public AudioSource _audioSource;
    public GameObject bloodBoom;
    public GameObject[] guards;
    public float MoveSpeed;
    public Animator anim;

    


    // Start is called before the first frame update
    public float checkTime = 0.1f;
    public float checkDistance = 0.1f;

    [Header("Must Be Setup")]
    public GameObject key;
    public DoorOpener doorToOpen;
    private bool activated = false;
    private GameObject guard;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DetectKey");
    }

    IEnumerator DetectKey()
    {
        while (Vector3.Distance(transform.position, key.transform.position) >= checkDistance)
        {
            yield return new WaitForSeconds(checkTime);
        }
        // door unlocked
        
        doorToOpen.OpenDoor();
        activated = true;
        Destroy(key);

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            for (int i = 0; i < guards.Length; i++){
                if(guards[i] != null)
                {
                    if(guard != null)
                    {
                        if(Vector3.Distance(transform.position, guard.transform.position) > Vector3.Distance(transform.position, guards[i].transform.position))
                        {
                            guard = guards[i];
                        }
                    } else
                    {
                        guard = guards[i];
                    }
                }
            }
            anim.SetBool("isMoving", true);
            transform.LookAt(guard.transform);
            transform.position += new Vector3(transform.forward.x * MoveSpeed * Time.deltaTime, transform.forward.y * MoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("e");
        if (collision.gameObject.tag == "Guard")
        {
            Debug.Log("yes");
            PlayMusic();
            Instantiate(bloodBoom, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            this.transform.position += new Vector3(500,0,0);
            Destroy(this.gameObject, 5f);
        } else if (collision.gameObject.name == "Guardbutt"){
            PlayMusic();
            Instantiate(bloodBoom, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject.transform.parent.gameObject);
            this.transform.position += new Vector3(500,0,0);
            Destroy(this.gameObject, 5f);
        }
    }

    public void PlayMusic()
    {
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
