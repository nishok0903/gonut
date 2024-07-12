using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPotionScript : MonoBehaviour
{
    public Material mat;
    public Material playerMaterial;
    static public float timeElapsed;
    bool isGulping;
    Collider player;
    static InvincibilityPotionScript lastInstance;
    //public PowerUpBarControllerScript bar;

    private void Update()
    {
        if (isGulping && lastInstance == this)
        {
            if (timeElapsed < 3f)
            {
                timeElapsed += Time.deltaTime;
                //PowerUpBarControllerScript.durationElapsed = timeElapsed;
            }
            else
            {
                isGulping = false;
                player.transform.GetChild(0).GetComponent<Renderer>().material = playerMaterial;
                player.GetComponent<PlayerMovementScript>().isInvincible = false;
                Debug.Log("Not Invincible Anymore!!!");

                Destroy(gameObject);
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastInstance = this;
            timeElapsed = 0;
            player = other;
            FindObjectOfType<AudioManager>().Play("PowerUp");
            other.GetComponent<PlayerMovementScript>().isInvincible = true;
            other.transform.GetChild(0).GetComponent<Renderer>().material = mat;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            isGulping = true;
            
        }  
        
    }
}
