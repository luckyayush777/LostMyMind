using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 directionToMove;
    private static int count = 1;
    private MovementPointSpawner spawnerScript;
    [SerializeField]
    private float speed;

    void Start()
    {
        spawnerScript = FindObjectOfType<MovementPointSpawner>();
        if(spawnerScript == null)
        {
            Debug.Log("Could not find MovementPointSpawner");
        }
    }

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
            Destroy(gameObject);
       }
    }

    private void MovementToWayPoints()
    {
        if ( count < spawnerScript.movementPoints.Count)
        {
            if (target.x - transform.position.x <= 0.01f)
                count++;
            target = spawnerScript.movementPoints[count].position;
            directionToMove = target - transform.position;
            transform.Translate(directionToMove.normalized * speed);
        }
    }   


}
