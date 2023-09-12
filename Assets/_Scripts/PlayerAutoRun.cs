using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoRun : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2f;

    [SerializeField]
    private GameObject stickman;

    private Vector3 tempVector = Vector3.zero;


    void FixedUpdate()
    {
        tempVector = stickman.GetComponent<Rigidbody>().velocity;
        tempVector.z = playerSpeed;
        stickman.GetComponent<Rigidbody>().velocity = tempVector;
    }
}
