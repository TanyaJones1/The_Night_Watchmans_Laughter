using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Digging : MonoBehaviour
{
    [SerializeField] private bool isDigging = false;

    [SerializeField] private float diggingTimer;
    [SerializeField] private int mimDigTimer = 30;
    [SerializeField] private int maxDigTimer = 60; 


    public void StartDigging()
    {
        isDigging = true;
        diggingTimer = RandomNumberGenerator.GetInt32(mimDigTimer, maxDigTimer);
        Debug.Log("StartDigging is starting");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDigging == true)
        {
            //add animation here
        }

        if (isDigging == true && diggingTimer > 0) 
        {
            diggingTimer -= Time.deltaTime;
        }
        if (isDigging == true && diggingTimer <= 0)
        {
            EnemyMoveAI enemyMoveAI = this.GetComponent<EnemyMoveAI>();
            enemyMoveAI.RunToExit();
            Debug.Log("Running To The Exit"); 
            this.enabled = false;
        }
    }

}
