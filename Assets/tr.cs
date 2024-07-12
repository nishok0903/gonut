using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tr : MonoBehaviour
{
    public PowerupController controller;
    public Slider slider;
    public float c;
    public int sliderID;
    public Powerup thisPowerup;
    public Color barColor;
    // Start is called before the first frame update
    void Start()
    {
        
        controller = GameObject.Find("PowerupController").GetComponent<PowerupController>();
        slider = GetComponent<Slider>();
        thisPowerup = controller.keys[sliderID];
        GetComponentInChildren<Image>().color = thisPowerup.barClr;
    }

    // Update is called once per frame
    void Update()
    {
        c = controller.activePowerups[thisPowerup]/5;
        slider.value = c;
        if (slider.value <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
