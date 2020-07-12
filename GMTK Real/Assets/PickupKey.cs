using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject monster;
    public float MoveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Monster")
        {
            
            transform.LookAt(monster.transform);

            transform.position += new Vector3(transform.forward.x * MoveSpeed * Time.deltaTime, transform.forward.y * MoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
