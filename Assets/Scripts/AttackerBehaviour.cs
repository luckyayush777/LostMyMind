using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dirToMove = Vector3.zero;
    [SerializeField]
    private float speed;
    public Lanes currentLane = Lanes.INVALID_LANE;
    
    void Start()
    {
        //Debug.Log(currentLane);
    }

    // Update is called once per frame
    void Update()
    {
        MovementToEndPoint();
        CheckLane();
    }
    
    private void MovementToEndPoint()
    {
        dirToMove = AttackBehaviour.dirToMove;
        transform.Translate(dirToMove.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lever")
        {
            //Debug.Log("hit lever!");
        }
        else if (collision.gameObject.tag == "face")
        {
            //Debug.Log("face hit!");
            AttackBehaviour.hitFace = true;
            Destroy(gameObject);

        }
    }

    private void CheckLane()
    {
        if((int)currentLane == AttackBehaviour.IDofCurrentLiverTouched)
        {
            AttackBehaviour.touchedLaneButton = true;
            Destroy(gameObject);
        }
    }
}
