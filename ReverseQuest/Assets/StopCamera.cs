using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Undead"))
        {
            GlobalVars.canMove = false;
        }
    }
}
