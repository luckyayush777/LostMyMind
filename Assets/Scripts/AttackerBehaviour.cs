using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lanes{
    NORTH_LANE,
    WEST_LANE,
    SOUTH_LANE,
    EAST_LANE
}

public class AttackerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dirToMove = Vector3.zero;
    [SerializeField]
    private float speed;
    public Lanes currentLane;
    
    void Start()
    {
        //Debug.Log(currentLane);
    }

    // Update is called once per frame
    void Update()
    {
        MovementToEndPoint();
        if(currentLane == Lanes.WEST_LANE)
        {
            if(AttackBehaviour.currentButtonClicked == 1)
            {
                Debug.Log("DESTROY!");
            }
        }else if(currentLane == Lanes.NORTH_LANE)
        {
            if (AttackBehaviour.currentButtonClicked == 2)
            {
                Debug.Log("DESTROY!");
            }
        }
        else if(currentLane == Lanes.EAST_LANE)
        {
            if (AttackBehaviour.currentButtonClicked == 3)
            {
                Debug.Log("DESTROY!");
            }
        }
        else if(currentLane == Lanes.SOUTH_LANE)
        {
            if (AttackBehaviour.currentButtonClicked == 4)
            {
                Debug.Log("DESTROY!");
            }
        }

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
}
