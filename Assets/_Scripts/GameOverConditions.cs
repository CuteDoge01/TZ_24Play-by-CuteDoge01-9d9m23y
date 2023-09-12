using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverConditions : MonoBehaviour
{
    private GameController controller;
    void Start()
    {
        controller = GameObject.Find("World").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision) //This only detects ground colisions
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            controller.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other) //This only detects wall colisions
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Enemy")
        {
            controller.GameOver();
        }
    }
}
