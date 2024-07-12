using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public float RotationPerSecond = 1.5f;
    private bool isRotating = true;

    public static SkyboxRotator instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    protected void Update()
    {
        if (isRotating) RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
        if (Input.GetKeyDown("t"))
        {
            ToggleSkyboxRotation();
        }
    }

    public void ToggleSkyboxRotation()
    {
        isRotating = !isRotating;
    }
}