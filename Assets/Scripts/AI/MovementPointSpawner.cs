using System.Collections.Generic;
using UnityEngine;

public class MovementPointSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Waypoint Properties")]
    public List<Transform> movementPoints = new List<Transform>();
    [SerializeField]
    private float distanceBetweeenPoints;
    [SerializeField]
    private Vector3 startingPoints;
    [SerializeField]
    private int noOfPoints;
    [SerializeField]
    private GameObject wayPoint;
    [SerializeField]
    private float radians;

    private float yCoordinate;
    private float xCoordinate;

    void Start()
    {
        InitialSetup();
        CalculateCoordinates();
        AddToWayPoints();
    }

    void Update()
    {
        
    }

    private void InitialSetup()
    {
        xCoordinate = startingPoints.x;
        yCoordinate = startingPoints.y;
    }

    private void CalculateCoordinates()
    {
        for (int i = 0; i < noOfPoints; i++)
        {
            Instantiate(wayPoint, new Vector3(xCoordinate, yCoordinate, -1.0f), Quaternion.identity , transform);
            wayPoint.gameObject.tag = "secondaryWaypoint";
            yCoordinate += distanceBetweeenPoints;  
            xCoordinate += (distanceBetweeenPoints * Mathf.Tan(radians));
            
        }
    }

    private void AddToWayPoints()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("secondaryWaypoint" ))
        {
            movementPoints.Add(g.transform);
        }
    }
}
