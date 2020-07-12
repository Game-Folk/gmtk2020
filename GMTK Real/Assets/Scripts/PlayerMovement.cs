using System.Collections;
using UnityEngine;
using Pathfinding;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public float distanceFromTargetToStop = 0.1f;
    public float checkSpeed = 0.1f;
    public LevelController levelController;
    public GhostMovement ghostMovement;
    public AIPath aIPath;
    public AIDestinationSetter aIDestinationSetter;

    private Vector2 pos; // For movement
    private Vector2? nextPos;
    //private bool moving = false;
    private bool emptyingQueue = false;
    
    void Start () {
        levelController = (LevelController)FindObjectOfType(typeof(LevelController));
        pos = transform.position; // Take the initial position
    }

    void Update(){
        if(aIPath.velocity.x < 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if( aIPath.velocity.x > 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void startMovement(){
        if(isMoving()){ // don't start dequeueing movements again until finished dequeueing
            return;
        }

        // dequeue a pos until queue empty
        emptyingQueue = true;
        //findNextPos();
        StartCoroutine("processQueue");
    }

    void findNextPos(){
        nextPos = levelController.dequeueMove();
        if(nextPos != null){
            pos = (Vector2)nextPos;
        }
    }

    public bool isMoving(){
        return emptyingQueue;
    }

    IEnumerator processQueue(){
        GameObject[] numbers = levelController.returnNumbers();
        int numOfNumbers = levelController.returnNumOfNumbers();
        for(int i = 0; i < numOfNumbers; i++){
            aIDestinationSetter.target = numbers[i].transform;
            while(Vector3.Distance (transform.position, numbers[i].transform.position) >= distanceFromTargetToStop){
                yield return new WaitForSeconds(checkSpeed);
            }
        }
        /*while(nextPos != null){ 
            if(moving == false){
                moving = true;
                StartCoroutine("Move");
            }
            yield return new WaitForSeconds(checkSpeed);
        }*/
        ghostMovement.resetSteps();
        levelController.resetSteps();
        emptyingQueue = false;
    }

    /*IEnumerator Move(){
        //while( !aIPath.TargetReached ){
        //    aIDestinationSetter.target = (Vector2)pos;
        //    yield return new WaitForSeconds(checkSpeed);
        //}
        while( (Vector2)transform.position != pos ){
            // Move there
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)pos, Time.deltaTime * speed);  
            yield return null;
        }
        findNextPos();
        moving = false;
    }*/
}
