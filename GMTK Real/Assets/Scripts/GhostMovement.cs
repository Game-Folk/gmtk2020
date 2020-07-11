using System.Collections;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public LevelController levelController;

    private Vector2 pos; // For movement
    private bool moving = false;
    
    void Start () {
        pos = transform.position; // Take the initial position
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.A) && moving == false) {              // Left
            moving = true;
            pos += Vector2.left;
            StartCoroutine("Move");
        } else if(Input.GetKey(KeyCode.D) && moving == false) {       // Right
            moving = true;
            pos += Vector2.right;
            StartCoroutine("Move");
        } else if(Input.GetKey(KeyCode.W) && moving == false) {       // Up
            moving = true;
            pos += Vector2.up;
            StartCoroutine("Move");
        } else if(Input.GetKey(KeyCode.S) && moving == false) {       // Down
            moving = true;
            pos += Vector2.down;
            StartCoroutine("Move");
        }
    }

    IEnumerator Move(){
        while( (Vector2)transform.position != pos ){
            // Move there
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);  
            yield return null;
        }
        levelController.enqueueMove(pos);
        moving = false;
    }
}
