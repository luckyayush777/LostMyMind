using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 directionToMove;
    private static int count = 1;
    private MovementPointSpawner spawnerScript;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(speed);
        spawnerScript = FindObjectOfType<MovementPointSpawner>();
        if(spawnerScript == null)
        {
            Debug.Log("Could not find MovementPointSpawner");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        MovementToWayPoints();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if ( collision.gameObject.CompareTag("face"))
       {
            EnemySpawner.brokenHeartEnemyHitFace = true;
            count = 1;
            //Debug.Log("face");
            Destroy(gameObject);
       }
    }

    private void MovementToWayPoints()
    {
        if ( count < spawnerScript.movementPoints.Count)
        {
            //Debug.Log("made it into the loop!");
            if (target.x - transform.position.x <= 0.01f)
                count++;
            target = spawnerScript.movementPoints[count].position;
            //Debug.Log(spawnerScript.movementPoints[count].position);
            //Debug.Log(target);
            directionToMove = target - transform.position;
            transform.Translate(directionToMove.normalized * speed);
            //Debug.Log(count);  
        }
    }   


}
