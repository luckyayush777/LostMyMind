using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTouchManager : MonoBehaviour
{
    Vector3 touchPosWorld;

    TouchPhase touchPhase = TouchPhase.Ended;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {


            touchPosWorld.x = Input.GetTouch(0).position.x;
            touchPosWorld.y = Input.GetTouch(0).position.y;
            touchPosWorld.z = 10.0f;
            touchPosWorld = Camera.main.ScreenToWorldPoint(touchPosWorld);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            Debug.DrawRay(touchPosWorld2D, Camera.main.transform.forward, Color.red);

            if (hitInformation.collider != null)
            {
                GameObject touchedObject = hitInformation.transform.gameObject;
                Debug.Log("Touched " + touchedObject.transform.name);
            }
        }
    }
}
