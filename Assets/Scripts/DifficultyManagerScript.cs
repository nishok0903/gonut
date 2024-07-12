using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManagerScript
{
    static float secondsToMaxDifficulty = 50f;
    public static float levelRunningTime = 0;


    public static float GetDifficultyPercent()
    {
        levelRunningTime += Time.deltaTime; 
        return Mathf.Clamp01(levelRunningTime / secondsToMaxDifficulty);
    }

}
