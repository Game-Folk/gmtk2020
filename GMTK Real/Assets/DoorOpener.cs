using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Collider2D collider;
    [Header("Must Be Setup")]
    public Animator doorAnimator;

    public void OpenDoor(){
        doorAnimator.SetBool("Opened", true);
        collider.enabled = false;
    }
}
