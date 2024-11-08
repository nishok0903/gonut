
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 500f;
    public float x;
    public LevelGenerator layoutGenerator;      

    void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;
        cameraPosition.x = 0f;
        x = layoutGenerator.kapathu;

        if (cameraPosition.magnitude > threshold)
        {

            for (int z = 0; z < SceneManager.sceneCount; z++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                {
                    g.transform.position -= cameraPosition;
                }
            }

            Vector3 originDelta = Vector3.zero - cameraPosition;
            layoutGenerator.UpdateSpawnOrigin(originDelta, x);
            Debug.Log("recentering, origin delta = " + originDelta);
        }

    }
}
