using System.Collections;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public int stepsAllowed = 15;
    public LevelController levelController;
    // numberList has to match stepsAllowed, but 15 is required to show in inspector
    public GameObject[] numbersList = new GameObject[15];

    private Vector2 pos; // For movement
    private bool moving = false;
    private int stepsTaken;
    private GameObject[] numbersInstantiated;
    
    void Start () {
        levelController = (LevelController)FindObjectOfType(typeof(LevelController));
        pos = transform.position; // Take the initial position
        stepsTaken = 0;
        numbersInstantiated = new GameObject[stepsAllowed];
    }

    void FixedUpdate(){
        if(stepsTaken >= stepsAllowed){ // out of steps, don't let ghost move
            return;
        }

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

        // create number
        numbersInstantiated[stepsTaken] = Instantiate(numbersList[stepsTaken], transform.position, Quaternion.identity);
        
        stepsTaken++;

        // add the position of the monster to the queue
        levelController.enqueueMove(pos);

        // allow more movement
        moving = false;
    }

    public void resetSteps(){
        stepsTaken = 0;

        // delete numbers
        for(int i = 0; i < numbersInstantiated.Length; i++){
            Destroy(numbersInstantiated[i]);
        }
    }
}
