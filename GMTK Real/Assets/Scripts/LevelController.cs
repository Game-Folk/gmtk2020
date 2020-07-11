using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private LinkedList<Vector2> moveQueue;

    void Start(){
        moveQueue = new LinkedList<Vector2>();
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

}
