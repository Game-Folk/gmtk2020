using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotting : MonoBehaviour
{

    public float playerspeed;


    private Vector3 defaultScale;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        //defaultPos = transform.position;
    }   

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {

            transform.localScale -= new Vector3(playerspeed * Time.deltaTime * 3, 0, 0);
            //transform.position -= new Vector3(playerspeed * Time.deltaTime, 0, 0);
        }
        if (collision.gameObject.name == "Monster")
        {
            Debug.Log("MONSTER SPOTTED");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        transform.localScale = defaultScale;
        //transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x + 1.8217f, 0.1936f, 0);
    }
}
