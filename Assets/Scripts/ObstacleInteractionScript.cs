using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInteractionScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<PlayerMovementScript>().isInvincible == false)
        {

            Debug.Log("Game Over!!!");
            other.GetComponent<PlayerMovementScript>().forwardSpeed = 0f;
            other.GetComponent<BoxCollider>().isTrigger = false;
            other.GetComponent<Rigidbody>().isKinematic = false;                      
            UIManagementScript.isOver = true;

        }
    }

}
