using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Spirit spirit = other.transform.GetComponent<Spirit>(); 
        if (other.CompareTag("Player"))
        {

            spirit.PickupPower();
            Debug.Log("Powerup Picked up"); 
        }
    }

}
