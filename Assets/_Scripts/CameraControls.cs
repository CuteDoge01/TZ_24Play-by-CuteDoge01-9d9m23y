using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private GameObject stickman;

    private float camZ;
    private Vector3 tempVector;

    private void Start()
    {
        camZ = transform.InverseTransformPoint(stickman.transform.position).z;
    }
    void FixedUpdate()
    {
        tempVector = transform.position;
        tempVector.z = stickman.transform.position.z - camZ;
        transform.position = tempVector;
    }
}
