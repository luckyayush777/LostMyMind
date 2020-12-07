using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dirToMove = Vector3.zero;
    [SerializeField]
    private float speed = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementToEndPoint();
    }
    
    private void MovementToEndPoint()
    {
        dirToMove = AttackBehaviour.dirToMove;
        transform.Translate(dirToMove.normalized * speed * Time.deltaTime);
    }
}
