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

    [SerializeField]
    private float blockHeight = 1.0f;

    private Vector3 tempVector = Vector3.zero;
    private Animator animator;
    private const float positionDelta = 0.1f; //Additional small jump distance will help with the game feel, esp with unity physics allowing objects to slightly clip into each other
    private float gameOverTimer = 0.3f;
    private ParticleSystem ps;

    private void Start()
    {
        animator = stickman.GetComponent<Animator>();
        ps = stickman.GetComponent<ParticleSystem>();
    }

    public void TriggerEntered(PlayerBlockLogic childScript, Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            stickman.transform.position += new Vector3(0, blockHeight + positionDelta, 0);
            tempVector = stickman.transform.position;
            tempVector.y = blockHeight/2 + positionDelta; // The origin point of the player block is at the center, so this accounts for that to Instantiate at the correct position
            Instantiate(PlayerCube, tempVector, Quaternion.identity, this.transform);
            Jump();
        }
        if (other.gameObject.tag == "Enemy")
        {
            childScript.gameObject.transform.SetParent(null);
            Handheld.Vibrate();
        }
    }

    private void Jump()
    {
        this.transform.SetParent(null);
        stickman.transform.position += (new Vector3(0, jumpHeight, 0));
        this.transform.SetParent(stickman.transform);
        animator.SetBool("Jump", true);
        ps.Play();
    }
    public void CallGameOver()
    {
        GameObject.Find("World").GetComponent<GameController>().GameOver();
    }

    void FixedUpdate()
    {
        if (this.transform.childCount == 0)
        {
            GameObject.Find("Main Camera").GetComponent<CameraControls>().enabled = false;
            stickman.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Invoke("CallGameOver", gameOverTimer);
        }
        foreach (Transform child in this.transform) //Forces the cubes to be underneath the stickman, while allowing for Unity physics to work for gravity(Y)
        {
            tempVector = child.position;
            tempVector.z = stickman.transform.position.z;
            tempVector.x = stickman.transform.position.x;
            child.position = tempVector;
        }
    }
}
