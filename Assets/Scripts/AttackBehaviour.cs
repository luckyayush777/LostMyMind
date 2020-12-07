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
        Debug.Log(CountOfSpawnObjects);
        pointToSpawn = Random.Range(0, CountOfSpawnObjects);
        Debug.Log(pointToSpawn);
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
        Debug.Log(dirToMove);
    }

}
