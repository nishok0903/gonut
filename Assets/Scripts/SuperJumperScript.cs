using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumperScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            
            
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        FindObjectOfType<AudioManager>().Play("PowerUp");
        PlayerMovementScript playerMovement = player.GetComponent<PlayerMovementScript>();
        playerMovement.jumpHeight = 5f;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        playerMovement.jumpHeight = 1f;
        Debug.Log("Reduced");
        Destroy(gameObject);

    }

}


