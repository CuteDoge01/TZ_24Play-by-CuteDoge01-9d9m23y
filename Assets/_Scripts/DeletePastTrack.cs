using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePastTrack : MonoBehaviour
{
    [SerializeField]
    private float deleteDistancePastPlayer = 100f;
    private void FixedUpdate()
    {
        if (GameObject.Find("Stickman").transform.position.z - this.transform.position.z > deleteDistancePastPlayer)
        {
            this.gameObject.SetActive(false);
        }
    }
}
