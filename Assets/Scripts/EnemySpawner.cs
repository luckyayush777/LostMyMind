using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heartEnemy;
    [SerializeField]
    private float delayBeforeNewEnemy;
    public static bool brokenHeartEnemyHitFace = false;
    private float time;
    void Start()
    {
        InitHeartEnemy();
    }

    void Update()
    {
        if(brokenHeartEnemyHitFace)
        {
            time += Time.deltaTime;
            if(time > delayBeforeNewEnemy)
            InitHeartEnemy();
            
        }
    }

    private void InitHeartEnemy()
    {
        time = 0.0f;
        Instantiate(heartEnemy);
        brokenHeartEnemyHitFace = false;
    }



    
}
