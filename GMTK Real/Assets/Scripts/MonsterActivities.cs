using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActivities : MonoBehaviour
{


    public GameObject guard;
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(guard.transform);
        transform.position += new Vector3(transform.forward.x * MoveSpeed * Time.deltaTime, transform.forward.y * MoveSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
