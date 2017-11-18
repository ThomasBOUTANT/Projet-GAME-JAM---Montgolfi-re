﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private float minCameraZ; //la camera ne va pas plus haut 
    private float maxCameraZ; // la camera ne va pas plus bas 

    [SerializeField]
    private float marginCameraZ;

    // Use this for initialization 
    void Start()
    {
        minCameraZ = player.GetComponent<PlayerMovement>().GetMinPlayerZ() + marginCameraZ;
        maxCameraZ = player.GetComponent<PlayerMovement>().GetMaxPlayerZ() - marginCameraZ;
    }

    // Update is called once per frame 
    void Update()
    {
        float newX = player.transform.position.x;
        float newZ = player.transform.position.z;

        if (newZ < minCameraZ || newZ > maxCameraZ)
        {
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
    }
}
