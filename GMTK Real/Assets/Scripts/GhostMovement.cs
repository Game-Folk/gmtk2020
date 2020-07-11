using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    private Vector3 pos; // For movement
    private bool moving = false;
    
    void Start () {
        pos = transform.position; // Take the initial position
    }

    void Update(){
        if(Input.GetKey(KeyCode.A) && transform.position == pos) {              // Left
            pos += Vector3.left;
            Move();
        } else if(Input.GetKey(KeyCode.D) && transform.position == pos) {       // Right
            pos += Vector3.right;
        } else if(Input.GetKey(KeyCode.W) && transform.position == pos) {       // Up
            pos += Vector3.up;
        } else if(Input.GetKey(KeyCode.S) && transform.position == pos) {       // Down
            pos += Vector3.down;
        }
    }
 
    /*void FixedUpdate () {
        if(Input.GetKey(KeyCode.A) && transform.position == pos) {              // Left
            pos += Vector3.left;
        } else if(Input.GetKey(KeyCode.D) && transform.position == pos) {       // Right
            pos += Vector3.right;
        } else if(Input.GetKey(KeyCode.W) && transform.position == pos) {       // Up
            pos += Vector3.up;
        } else if(Input.GetKey(KeyCode.S) && transform.position == pos) {       // Down
            pos += Vector3.down;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }*/

    IEnumerator Move(){
        while(transform.position != pos){
            // Move there
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);  

            yield return new WaitForSeconds(0.1f);  
        }
    }
}
