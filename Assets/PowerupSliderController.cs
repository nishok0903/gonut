using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerupSliderController : MonoBehaviour
{

    public GameObject powerupSliderPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void SpawnSlider(int key)
    {
        Vector3 spawnPosition = new Vector3(160f, ((float)key * 30f) + 10f, 0f);
        GameObject powerupSliderGameObject = Instantiate(powerupSliderPrefab);
        powerupSliderGameObject.transform.SetParent(this.transform);
        powerupSliderGameObject.transform.position = spawnPosition;
        tr powerupSlider = powerupSliderGameObject.GetComponent<tr>();
        powerupSlider.sliderID = key;
    }

    public void AdjustSlider()
    { }
}
