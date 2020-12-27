using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite faceAfterOneHit = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "attacker")
        {
            this.GetComponent<SpriteRenderer>().sprite = faceAfterOneHit;
        }
    }
}
