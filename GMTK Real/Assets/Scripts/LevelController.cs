using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelController : MonoBehaviour
{
    public int stepsAllowed = 15;
    public GridLayout gridLayout;
    public PlayerMovement playerMovement;
    // numberList has to match stepsAllowed, but 15 is required to show in inspector
    public GameObject[] numbers = new GameObject[15];

    private Camera cam;
    private LinkedList<Vector2> moveQueue;
    private int stepCount = 0;
    private GameObject[] numbersInstantiated;

    void Start(){
        gridLayout = (GridLayout)FindObjectOfType(typeof(GridLayout));
        playerMovement = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
        cam = Camera.main;
        moveQueue = new LinkedList<Vector2>();
        numbersInstantiated = new GameObject[stepsAllowed];
    }

    void Update(){
        if (Input.GetMouseButtonDown(0) && !playerMovement.isMoving()){ // left click
            if(EventSystem.current.IsPointerOverGameObject()){
                return;
            }

            // convert click coords to cell, and then to the center of the cell
            Vector2 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = gridLayout.WorldToCell(clickPos);
            clickPos = (Vector2)gridLayout.CellToWorld(cellPosition) + new Vector2(0.5f,0.5f);

            // store the instantiated numbers
            numbersInstantiated[stepCount] = Instantiate(numbers[stepCount], clickPos, Quaternion.identity);
            
            // queue the movements
            enqueueMove(clickPos);

            stepCount++;
        }
    }

    /*
     * enqueueMove()
     * adds a vector2 position to moveQueue
     */
    public void enqueueMove(Vector2 pos){
        moveQueue.AddLast(pos);
    }

    /*
     * dequeueMove()
     * returns the vector2 at the beginning of the queue if it exists
     *         null otherwise
     */
    public Vector2? dequeueMove(){
        LinkedListNode<Vector2> v = moveQueue.First;

        if(v == null){ // check if there are any moves queued up.
            return null;
        }

        moveQueue.RemoveFirst();
        return v.Value;
    }

    public GameObject[] returnNumbers(){
        return numbersInstantiated;
    }
    public int returnNumOfNumbers(){
        return stepCount;
    }

    public void resetSteps(){
        stepCount = 0;

        // delete numbers
        for(int i = 0; i < numbersInstantiated.Length; i++){
            Destroy(numbersInstantiated[i]);
        }
    }

}
