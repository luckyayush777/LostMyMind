﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject TubeAttachedToThisLever;
    [SerializeField]
    private int leverID;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attacker")
        {
            //Debug.Log("ENTERED ATTACKER!");
        }
    }



    public int GetleverID()
    {
        return leverID;
    }
}
