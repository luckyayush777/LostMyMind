using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    private Vector3 touchPosWorld;
    public GameObject debugObject;
    [Header("Screen Offset")]
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    private string nameOfCurrentButtonTouched;



    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LogButtons();
    }

    private void LogButtons()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchPosWorld.x = Input.GetTouch(0).position.x;
            touchPosWorld.y = Input.GetTouch(0).position.y;
            touchPosWorld.z = 10.0f;
            //Debug.Log(touchPosWorld + " ");
            touchPosWorld = _mainCamera.ScreenToWorldPoint(touchPosWorld);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            //Debug.Log(touchPosWorld2D);
            Instantiate(debugObject, new Vector3(touchPosWorld2D.x, touchPosWorld2D.y , -1.0f), Quaternion.identity);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, _mainCamera.transform.forward);
            if(hitInformation.collider != null && hitInformation.collider.CompareTag("dirChangeButton"))
            {
                //Debug.Log(hitInformation.collider.gameObject.name);
                AttackBehaviour.CurrentButtonPressed = hitInformation.collider.GetComponent<DirChangeButton>().ReturnButtonName();
            }
            
            
        }
    }
}
