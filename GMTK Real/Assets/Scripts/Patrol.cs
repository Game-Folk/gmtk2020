using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float waitTime;
    public Transform[] movespots;
    public Animator anim;

    private float timeToWait;
    private int currspot;

    void Start()
    {
        timeToWait = waitTime;
        currspot = 0;
        directionFacingHelper();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, movespots[currspot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movespots[currspot].position) < .2f)
        {
            if (timeToWait <= 0)
            {
                if (currspot == (int)movespots.Length - 1)
                {
                    currspot = 0;

                    directionFacingHelper();
                }
                else
                {
                    currspot++;
                    directionFacingHelper();
                }
                timeToWait = waitTime;
            }
            else
            {
                timeToWait -= Time.deltaTime;
            }
        }
    }

    void directionFacingHelper()
    {
        if (movespots[currspot].position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
