using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) {
            gameObject.transform.Translate(0,speed,0);
        } else if (Input.GetKey("a")){
            gameObject.transform.Translate(-speed,0,0);
        } else if (Input.GetKey("s")){
            gameObject.transform.Translate(0,-speed,0);
        } else if (Input.GetKey("d")){
            gameObject.transform.Translate(speed,0,0);
        }
    }

    
}
