using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 dirToMove = Vector3.zero;
    public float speed = 1.0f;
    public Lanes currentLane = Lanes.INVALID_LANE;
    private  bool primaryMovementAllowed = true;
    private  bool secondaryMovementAllowed = false;


    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        if (primaryMovementAllowed)
        {
            Movement();
        }else if(secondaryMovementAllowed)
        {
            SecondaryMovement();
        }
       CheckLane();
    }
    
    private void Movement()
    {
        dirToMove = AttackBehaviour.dirToMove;
        transform.Translate(dirToMove.normalized * speed * Time.deltaTime);
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lever"))
        {
           
        }
        else if (collision.gameObject.CompareTag("face"))
        {
            AttackBehaviour.hitFace = true;
            Destroy(gameObject);

        }
        else if(collision.gameObject.CompareTag("waypoint"))
        {
            string identifier;
            if (currentLane == Lanes.EAST_LANE || currentLane == Lanes.WEST_LANE)
            {
                identifier = collision.GetComponent<Waypoint>().GetHorizontalIdentifer();
                //Helper.Log(identifier);
            }
            else if (currentLane == Lanes.NORTH_LANE || currentLane == Lanes.SOUTH_LANE)
            {
                identifier = collision.GetComponent<Waypoint>().GetVerticalIdentifier();
                //Helper.Log(identifier);
            }
            else 
                identifier = null;
            CalibrateDirection(identifier);
        }
        else if(collision.gameObject.CompareTag("boundary"))
        {
            Helper.Log("hit boundary");
            AttackBehaviour.hitBoundary = true;
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
    
    private void SecondaryMovement()
    {
       transform.Translate(dirToMove.normalized* speed * Time.deltaTime);
    }

    private void CalibrateDirection(string identifier)
    {
        primaryMovementAllowed = false;
        secondaryMovementAllowed = true;
        Helper.ASSERT_STRING(identifier);
        if (identifier == "RedirectRight")
        {
            dirToMove = Vector2.zero;
            dirToMove = Vector2.right;
        }
        else if(identifier == "RedirectDown")
        {
            dirToMove = Vector2.zero;
            dirToMove = Vector2.down;
        }else if(identifier == "RedirectUp")
        {
            dirToMove = Vector2.zero;
            dirToMove = Vector2.up;
        }else if(identifier == "RedirectLeft")
        {
            dirToMove = Vector2.zero;
            dirToMove = Vector2.left;
        }
    }

}
