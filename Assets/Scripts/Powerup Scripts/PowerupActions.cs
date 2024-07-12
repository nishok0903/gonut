using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementScript playerController;

    public void SuperJumperStartAction()
    {
        playerController.jumpHeight = 4f;
    }

    public void SuperJumperEndAction()
    {
        playerController.jumpHeight = 1f;
    }

    public void InvincibilityStartAction()
    {
        //playerController.transform.GetComponent<BoxCollider>().enabled = false;
        playerController.isInvincible = true;
    }

    public void InvincibilityEndAction()
    {
        playerController.isInvincible = false;
    }

}
