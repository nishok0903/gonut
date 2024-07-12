using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    //public GameObject powerupPrefab;

    public List<Powerup> powerups;

    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();

    public List<Powerup> keys = new List<Powerup>();

    public PowerupSliderController controller;
    #region Global Powerup Functions

    // Handles the beginning and ending of activated Powerups.
    // Inactive Powerups are removed automatically.
    private void HandleGlobalPowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0)
        {
            foreach (Powerup powerup in keys)
            {
                if (activePowerups[powerup] > 0)
                {
                    activePowerups[powerup] -= Time.deltaTime;
                }
                else
                {
                    changed = true;

                    activePowerups.Remove(powerup);

                    //if (powerup.endAction != null)
                    powerup.End();
                }
            }
        }

        if (changed)
        {
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    // Adds a global Powerup to the activePowerups list.
    public void ActivatePowerup(Powerup powerup)
    {
        bool isChanged = false;
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.Start();
            activePowerups.Add(powerup, powerup.duration);
            isChanged = true;
        }
        else
        {
            activePowerups[powerup] = powerup.duration;
        }

        keys = new List<Powerup>(activePowerups.Keys);
        if (isChanged)
        {
            
            controller.SpawnSlider(keys.IndexOf(powerup));
            isChanged = false;
        }
    }

    // Calls the end action of each powerup and clears them from the activePowerups
    public void ClearActivePowerups()
    {
        foreach (KeyValuePair<Powerup, float> Powerup in activePowerups)
        {
            Powerup.Key.End();
        }

        activePowerups.Clear();
    }

    #endregion

    // checks for disabling global powerups
    void Update()
    {
        HandleGlobalPowerups();
    }

    // Spawns a powerup by given name at given position.
    public GameObject SpawnPowerup(Powerup powerup, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerup.powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerup);

        powerupGameObject.transform.position = position;

        return powerupGameObject;
    }

    public GameObject SpawnRandomPowerup(Vector3 position)
    {
        return SpawnPowerup(powerups[Random.Range(0, powerups.Count)], position);
    }
}
