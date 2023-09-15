using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField]
    private GameObject stickman;

    private Vector3 tempVector;

    void FixedUpdate()
    {
        tempVector = stickman.transform.position;
        tempVector.y = 0.05f;
        transform.position = tempVector;
    }
}
