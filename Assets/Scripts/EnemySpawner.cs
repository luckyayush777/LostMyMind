using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heartEnemy;
    public static bool brokenHeartEnemyHitFace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(brokenHeartEnemyHitFace)
        {
            InitHeartEnemy();
        }
    }

    private void InitHeartEnemy()
    {
        Instantiate(heartEnemy);
        brokenHeartEnemyHitFace = false;
    }



    
}
