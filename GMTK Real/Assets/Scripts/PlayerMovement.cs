using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public float checkSpeed = 0.1f;
    public LevelController levelController;

    private Vector2 pos; // For movement
    private Vector2? nextPos;
    private bool moving = false;
    
    void Start () {
        pos = transform.position; // Take the initial position
    }

    public void startMovement(){
        // dequeue a pos until queue empty
        findNextPos();
        StartCoroutine("processQueue");
    }

    void findNextPos(){
        nextPos = levelController.dequeueMove();
        if(nextPos != null){
            pos = (Vector2)nextPos;
        }
    }

    IEnumerator processQueue(){
        while(nextPos != null){ 
            if(moving == false){
                moving = true;
                StartCoroutine("Move");
            }
            yield return new WaitForSeconds(checkSpeed);
        }
    }

    IEnumerator Move(){
        while( (Vector2)transform.position != pos ){
            // Move there
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)pos, Time.deltaTime * speed);  
            yield return null;
        }
        findNextPos();
        moving = false;
    }
}
