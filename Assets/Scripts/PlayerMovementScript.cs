using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovementScript : MonoBehaviour
{
    #region Variable Declarations

    public Text gameDifficultyText;
    public bool isInvincible = false;

    bool isGrounded;
    Vector3 velocity;
    float gravity = -9.81f;    
    bool isShifting = false;   

    public float jumpHeight = 1f;
    public float forwardSpeed = 65f;

    #endregion
    void Update()
    {

        #region Horizontal Navigation
        if (Input.GetKeyDown("d") && transform.position.x < 3.5f && !isShifting && !UIManagementScript.isOver)
        {

            StartCoroutine(ShiftLane(transform.position.x + 3.5f, transform.position));
        }

        if (Input.GetKeyDown("a") && transform.position.x > -3.5 && !isShifting && !UIManagementScript.isOver)
        {
            StartCoroutine(ShiftLane(transform.position.x - 3.5f, transform.position));
        }
        #endregion

        #region Forward Motion
        if (UIManagementScript.isOver == false)
        { Time.timeScale = Mathf.Lerp(0.8f, 2f, DifficultyManagerScript.GetDifficultyPercent());            
        }
        gameDifficultyText.text = "Game Difficulty: " + ((UIManagementScript.isOver == false) ? Mathf.Round((((Time.timeScale - 0.8f)/1.2f)*100f)).ToString() + "%" : "0%");
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
#endregion

        //Ground Check
        isGrounded = transform.position.y <= 0.52;
        //Stabilizing Player on ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Applying gravitional acceleration on Player if not grounded 
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        // Applying vertical velocity to Player
        transform.Translate(0, velocity.y * 2f * Time.deltaTime, 0);
                      
    }    
    IEnumerator ShiftLane(float xTarget, Vector3 startPosition)
    {
        FindObjectOfType<AudioManager>().Play("Shift");
        isShifting = true;
        float duration = 0.15f;
        float time = 0;
        float xPos;
        
        while (time < duration)
        {
            xPos = Mathf.Lerp(startPosition.x, xTarget, time / duration);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
        xPos = xTarget;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        isShifting = false;
    }
}
