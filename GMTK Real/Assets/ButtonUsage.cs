using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUsage : MonoBehaviour
{
    public float checkTime = 0.1f;
    public float checkDistance = 0.1f;
    public Animator animator;
    
    [Header("Must Be Setup")]
    public GameObject monster;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DetectMonster");
    }

    IEnumerator DetectMonster(){
        while( Vector3.Distance(transform.position, monster.transform.position) >= checkDistance ){
            yield return new WaitForSeconds(checkTime);
        }
        // button pressed
        animator.SetBool("Pressed", true);
    }
}
