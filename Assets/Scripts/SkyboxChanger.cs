using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] Skyboxes;
    private int materialCount;
    private int lastMaterial;

    public static SkyboxChanger instance;

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

    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (materialCount <= 3) { materialCount += 1; } else if(materialCount == null) { materialCount = 0; }
            ChangeSkybox();
        }
    }

    public void ChangeSkybox()
    {
        if (materialCount == null)
        { RenderSettings.skybox = Skyboxes[0]; }
        else { RenderSettings.skybox = Skyboxes[materialCount]; }
       // RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}