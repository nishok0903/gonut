using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform primarySegment;
    [SerializeField] private Vector3 playerSpawnPosition;
    [SerializeField] private Vector3 primarySegmentSpawnPosition;
    [SerializeField] private Transform segmentCollection;

    void Start()
    {
        //Instantiating primary gameObjects
        Transform pS = Instantiate(primarySegment, primarySegmentSpawnPosition, Quaternion.identity);
        pS.transform.parent = segmentCollection;
        Destroy(pS.gameObject, 5f);
    }

}
