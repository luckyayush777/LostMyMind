using System;
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
    public static bool hitBoundary = false;
    public static int IDofCurrentLiverTouched = 0;
    public static bool touchedLaneButton = false;

    
    
    public static string CurrentButtonPressed { get; set; }
    public static string CurrentRegionName { get; set; }

    public static string nameOfLeverPressed { get; set; }
    void Start()
    {
        InitSpawnPointList();
        InitAttackerPrefab();
        InitEndPoints();
        CalculateMovementVector();
    }
    void Update()
    { 

        if(hitFace)
        {
            InitAttackerPrefab();
            CalculateMovementVector();
        }
        if(touchedLaneButton)
        {
            InitAttackerPrefab();
            CalculateMovementVector();
            touchedLaneButton = false;
        }
        else if(hitBoundary)
        {
            InitAttackerPrefab();
            CalculateMovementVector();
            hitBoundary = false;
        }
        if (CurrentButtonPressed != null)
        {
            dirToMove = RecalibrateDirection(dirToMove, CurrentButtonPressed);
            CurrentButtonPressed = null;
        }
        if (CurrentRegionName != null)
        {
            CurrentRegionName = null;
        }
        if(nameOfLeverPressed != null)
        {
            dirToMove = -dirToMove;
            nameOfLeverPressed = null;
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
        pointToSpawn = UnityEngine.Random.Range(0, CountOfSpawnObjects);
        SetLane(pointToSpawn);
        Instantiate(attackerObject, spawnPoints[pointToSpawn].position, Quaternion.identity);
        hitFace = false;
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
    }

    private void SetLane(int spawnpoint)
    {
        switch (spawnpoint)
        {
            case 0: attackerObject.GetComponent<AttackerBehaviour>().currentLane = Lanes.WEST_LANE;
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

    private Vector2 RecalibrateDirection(Vector2 originalVector, string directionToMoveTo)
    {
        if (directionToMoveTo == "NorthWest")
        {
            originalVector.x *= 0;
            originalVector.y += 1.0f;
        }
        else if (directionToMoveTo == "SouthWest")
        {
            originalVector.x *= 0;
            originalVector.y -= 1.0f;
        }
        else if (directionToMoveTo == "NorthEast")
        {
            originalVector.x += 1.0f;
            originalVector.y *= 0.0f;
        }
        else if (directionToMoveTo == "SouthEast")
        {
            originalVector.x -= 1.0f;
            originalVector.y *= 0.0f;
        }
        return originalVector;
    }








}
