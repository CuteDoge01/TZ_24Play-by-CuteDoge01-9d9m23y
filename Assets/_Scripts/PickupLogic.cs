using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject floatingText;
    [SerializeField]
    private float textHight = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(floatingText, GameObject.Find("Stickman").transform.position + new Vector3(0, textHight, 0), Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
