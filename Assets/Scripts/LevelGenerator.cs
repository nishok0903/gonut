using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region Variable Declarations

    private const float DISTANCE_FOR_SPAWNING_SEGMENT = 200f;

    [SerializeField] private Transform primarySegment;
    [SerializeField] private List<Transform> segmentTypeList;

    public Queue<GameObject> spawnedSegments = new Queue<GameObject>();
    public GameObject player;

    private Vector3 segmentOffset = new Vector3(0, 0, 25f);
    private Vector3 lastEndPosition = new Vector3(0, 0, 25f);
    private float amountOfDespawnsSkipped = 0f;
    public Vector3 spawnOrigin = Vector3.zero;
    public float kapathu;

    #endregion
    private void Awake()
    {
        lastEndPosition = primarySegment.Find("EndPoint").position + segmentOffset;
        int initialSegmentsLoaded = 2;
        for (int i = 0; i < initialSegmentsLoaded; i++)
        {
            SpawnSegment();
        }
    }

    void Start()
    {
        //Instantiating player object for checking distance

        player = GameObject.FindWithTag("Player");
        
    }
    private void Update()
    {
        //if distance is lesser than DISTANCE_FOR_SPAWNING_SEGMENT a segment is spawned
       // Debug.Log(player.transform.position.z +"   ///   "+lastEndPosition.z);
        kapathu = Mathf.Abs((player.transform.position.z) - lastEndPosition.z);
        if (Mathf.Abs((player.transform.position.z) - lastEndPosition.z) < DISTANCE_FOR_SPAWNING_SEGMENT)
        {
            
            SpawnSegment();
            if (amountOfDespawnsSkipped < 7f)
            { amountOfDespawnsSkipped += 1f; }
            else
            { Destroy(spawnedSegments.Dequeue());          
            }
        }
    }

    private void SpawnSegment()
    {
        Transform chosenSegment = segmentTypeList[Random.Range(0,segmentTypeList.Count)];
        Transform lastSegmentTransform = SpawnSegment(chosenSegment, lastEndPosition);
        lastEndPosition = lastSegmentTransform.Find("EndPoint").position + segmentOffset;

    }
    private Transform SpawnSegment(Transform Segment, Vector3 spawnPosition)
    { 
        Transform segmentTransform = Instantiate(Segment, spawnPosition, Quaternion.identity);
       // Debug.Log("///////////" + spawnOrigin);
       // segmentTransform.transform.parent = segmentCollection;
        spawnedSegments.Enqueue(segmentTransform.gameObject);
        return segmentTransform;

    }

    public void UpdateSpawnOrigin(Vector3 OriginDelta, float a)
    {
        spawnOrigin = spawnOrigin + OriginDelta;
        lastEndPosition +=  OriginDelta;
    }
}
