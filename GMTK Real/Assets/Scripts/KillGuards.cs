using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGuards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Guardbutt")
        {
            
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
