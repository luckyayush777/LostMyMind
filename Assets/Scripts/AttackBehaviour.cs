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
    public static int IDofCurrentLiverTouched = 0;
    public static bool touchedLaneButton = false;

    public QuartantMovement quartantMovement;
    public static string CurrentButtonPressed { get; set; }
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
        DebugInputLogger();
        if (CurrentButtonPressed != null)
        {
            dirToMove = RecalibrateDirection(dirToMove, CurrentButtonPressed);
            Debug.Log(CurrentButtonPressed);
            CurrentButtonPressed = null;
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
        pointToSpawn = Random.Range(0, CountOfSpawnObjects);
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
                //THIS IS BROKEN FOR SOME REASON, SOUTH AND EAST ARE INTERCHANGED
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
        else if(directionToMoveTo == "SouthWest")
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
    // DELETE THIS LATER
    private void DebugInputLogger()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            dirToMove = RecalibrateDirection(dirToMove, "SouthWest");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            dirToMove = RecalibrateDirection(dirToMove, "NorthWest");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dirToMove = RecalibrateDirection(dirToMove, "NorthEast");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dirToMove = RecalibrateDirection(dirToMove, "SouthEast");
        }
    }



}
