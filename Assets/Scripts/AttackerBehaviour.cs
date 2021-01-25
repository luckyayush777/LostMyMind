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
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckLane();
    }
    
    private void Movement()
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

        }else if(collision.gameObject.tag == "regionIdentifier")
        {
            //Debug.Log("HIT SOME REGION!");
            CalculateRegion(collision.gameObject.name);
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

    private void CalculateRegion(string regionHit)
    {
        if(regionHit == "SouthWestRegionIdentifier" || regionHit == "SouthWestRegionIdentifier2")
        {
            Debug.Log(regionHit);
        }else if(regionHit == "NorthEastRegionIdentifer" || regionHit == "NorthEastRegionIdentifer2")
        {
            Debug.Log(regionHit);
        }
        else if(regionHit == "NorthWestRegionIdentifer" || regionHit == "NorthWestRegionIdentifer2")
        {
            Debug.Log(regionHit);
        }
        else if(regionHit == "SouthEastRegionIdentifier" || regionHit == "SouthEastRegionIdentifier2")
        {
            Debug.Log(regionHit);
        }
        else
        {
            Debug.Log("INVALID REGION!");
        }
    }

    
}
