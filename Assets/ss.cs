using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    // Start is called before the first frame update
    public PowerupController controller;
    void Start()
    {
        controller = GameObject.Find("PowerupController").GetComponent<PowerupController>();
        controller.SpawnRandomPowerup(transform.position);
        Destroy(this.gameObject);
    }

}
