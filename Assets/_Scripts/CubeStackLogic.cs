using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CubeStackLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerCube;

    [SerializeField]
    private GameObject stickman;

    [SerializeField]
    private float jumpHeight = 1.0f;

    private Vector3 tempVector = Vector3.zero;

    Animator animator;

    private int numOfCubes = 1;

    private void Start()
    {
        animator = stickman.GetComponent<Animator>();
    }

    public void TriggerEntered(PlayerBlockLogic childScript, Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            stickman.transform.position += new Vector3(0, jumpHeight, 0);
            Instantiate(PlayerCube, stickman.transform.position - new Vector3(0, numOfCubes, 0), Quaternion.identity, this.transform);
            animator.SetBool("Jump", true);
            numOfCubes++;
            //Debug.Log(numOfCubes);
        }
        if (other.gameObject.tag == "Enemy")
        {
            childScript.gameObject.transform.SetParent(null);
            Handheld.Vibrate();
            numOfCubes--;
            //Debug.Log(numOfCubes);
        }
    }

    void FixedUpdate()
    {
        foreach (Transform child in this.transform) //Forces the cubes to be underneath the stickman, while allowing for Unity physics to work for gravity(Y)
        {
            tempVector = child.position;
            tempVector.z = stickman.transform.position.z;
            tempVector.x = stickman.transform.position.x;
            child.position = tempVector;
        }
    }
}
