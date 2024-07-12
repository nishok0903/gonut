using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform mainCamera;
    [SerializeField] Vector3 cameraOffset;
    void LateUpdate()
    {
        mainCamera.position = transform.position + cameraOffset;
    }
}
