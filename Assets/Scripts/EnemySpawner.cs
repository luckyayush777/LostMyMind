using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heartEnemy;
    public static bool brokenHeartEnemyHitFace = false;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        InitHeartEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(brokenHeartEnemyHitFace)
        {
            time += Time.deltaTime;
            if(time > 1.0f)
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
