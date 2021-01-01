using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite[] FacesAfterHit = new Sprite[6];
    private static int noOfTimesHit = 0;

    public delegate void OnDamage();
    public static event OnDamage tookDamage;
    
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
            tookDamage?.Invoke();
            GetComponent<SpriteRenderer>().sprite = FacesAfterHit[noOfTimesHit];
            if(noOfTimesHit + 1 < FacesAfterHit.Length)
            noOfTimesHit++;
        }
    }
}
