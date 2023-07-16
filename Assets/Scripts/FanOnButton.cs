using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOnButton : MonoBehaviour
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
        TurnTheFanOn();
    }

    private void TurnTheFanOn()
    {
        fanAnimator.SetTrigger("turnOn");
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }
}
