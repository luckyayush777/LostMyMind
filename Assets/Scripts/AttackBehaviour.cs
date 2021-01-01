using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject attackerObject;
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private List<Transform> endPoints = new List<Transform>();
    private int pointToSpawn = 0;
    public static Vector3 dirToMove = Vector3.zero;
    public static bool hitFace = false;
    public static int currentButtonClicked;
    void Start()
    {
        InitSpawnPointList();
        InitAttackerPrefab();
        InitEndPoints();
        CalculateMovementVector();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitFace)
        {
            //Debug.Log("DESTROYED INITING NEW!");
            InitAttackerPrefab();
            CalculateMovementVector();
            hitFace = false;
        }
    }

    private void InitSpawnPointList()
    {
        foreach(GameObject spawnObjects in GameObject.FindGameObjectsWithTag("StartSpawnPoint"))
        {
            spawnPoints.Add(spawnObjects.GetComponent<Transform>());
        }
    }

    private void InitAttackerPrefab()
    {
        int CountOfSpawnObjects = spawnPoints.Count;
        //Debug.Log(CountOfSpawnObjects);
        pointToSpawn = Random.Range(0, CountOfSpawnObjects);
        SetAttackerLaneInfo(pointToSpawn);
        Instantiate(attackerObject, spawnPoints[pointToSpawn].position, Quaternion.identity);
    }

    private void InitEndPoints()
    {
        foreach (GameObject endPointObjects in GameObject.FindGameObjectsWithTag("Endpoint")) 
        {
            endPoints.Add(endPointObjects.GetComponent<Transform>());
        }
    }

    private void CalculateMovementVector()
    {
        Transform endPointToMoveToTransform = endPoints[pointToSpawn];
        dirToMove = endPointToMoveToTransform.position - spawnPoints[pointToSpawn].position;
        //Debug.Log(dirToMove);
    }

    private void SetAttackerLaneInfo(int LaneInfoEnum)
    {
        switch (LaneInfoEnum)
        {
            case 0:
                attackerObject.GetComponent<AttackerBehaviour>().currentLane = Lanes.WEST_LANE;
                break;
            case 1:
                attackerObject.GetComponent<AttackerBehaviour>().currentLane = Lanes.NORTH_LANE;
                break;
            case 2:
                attackerObject.GetComponent<AttackerBehaviour>().currentLane = Lanes.SOUTH_LANE;
                break;
            case 3:
                attackerObject.GetComponent<AttackerBehaviour>().currentLane = Lanes.EAST_LANE;
                break;
        }
    }

   
}
