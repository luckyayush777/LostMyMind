using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 directionToMove;
    private static int count = 0;
    private MovementPointSpawner spawnerScript;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = FindObjectOfType<MovementPointSpawner>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovementToWayPoints();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("face"))
       {
            EnemySpawner.brokenHeartEnemyHitFace = true;
            Debug.Log("face");
            Destroy(gameObject);
       }
    }

    private void MovementToWayPoints()
    {
        if (count != spawnerScript.movementPoints.Count)
            target = spawnerScript.movementPoints[count].position;
        else if (count == spawnerScript.movementPoints.Count)
        {
            speed = 0;
            target = Vector3.zero;
        }
        if (count != spawnerScript.movementPoints.Count)
            directionToMove = (target - transform.position);
        else
            directionToMove = Vector3.zero;
        if (count < spawnerScript.movementPoints.Count && spawnerScript.movementPoints[count].position.z - transform.position.z <= 0.2f)
        {
            count++;
            Debug.Log(count);
        }
        transform.Translate(directionToMove.normalized * Time.deltaTime * speed, Space.World);
      
    }
}
