﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    Vector3 centerPosition;

    private GameObject Player;

    [SerializeField]
    private float detectionDistance;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        centerPosition = gameObject.GetComponent<Collider>().bounds.center;
    }


    // Update is called once per frame
    void Update()
    {
        bool IsPlayerNear = Vector3.Distance(Player.transform.position, centerPosition) < detectionDistance;

        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}