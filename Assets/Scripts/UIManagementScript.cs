using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManagementScript : MonoBehaviour
{

    public static int coinsCollected = 0;
    public Text coinText;

    public Transform player;
    public LevelGenerator lg;
    public Text score;
    public GameObject buttons;
    public Button restartbtn;
    public Button exitbtn;
    static public bool isOver = false;
    public bool isLerping = false;
    public float velocity = 0f;


    private void Start()
    {
        restartbtn.onClick.AddListener(Restart);
        exitbtn.onClick.AddListener(Exit);
        coinsCollected = 0;
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
            Debug.Log("Exitted");
        }
        else if (Input.GetKeyDown("r"))
        {
            Restart();
        }
        if (isOver == false)
        {
            score.text = (Mathf.Round((-lg.spawnOrigin.z + player.position.z))).ToString();
            coinText.text = coinsCollected.ToString();
        }
        else if(isOver == true)
        {
            buttons.SetActive(true);
            isLerping = true;
            DifficultyManagerScript.levelRunningTime = 0;
        }
        if (isLerping)
        {
            if(Time.timeScale >= 0.01f){ Time.timeScale -= 0.01f; }else { Time.timeScale = 0; }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isOver = false;
        isLerping = false;
        Time.timeScale = 1f;
    }

    private void Exit()
    {
        Application.Quit();
    }
}
