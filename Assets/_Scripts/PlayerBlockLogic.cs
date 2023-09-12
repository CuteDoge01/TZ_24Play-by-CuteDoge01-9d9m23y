using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent != null)
        {
            transform.parent.GetComponent<CubeStackLogic>().TriggerEntered(this, other);
        }
    }

}
