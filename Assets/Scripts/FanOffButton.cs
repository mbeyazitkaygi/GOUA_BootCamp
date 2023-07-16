using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOffButton : MonoBehaviour
{
    public GameObject fanObject; // Reference to the fan game object

    private Animator fanAnimator; // Animator component of the fan object

    private void Start()
    {
        // Get the Animator component of the fan object
        fanAnimator = fanObject.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        TurnTheFanOff();
    }

    private void TurnTheFanOff()
    {
        fanAnimator.SetTrigger("turnOff");
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }
}
