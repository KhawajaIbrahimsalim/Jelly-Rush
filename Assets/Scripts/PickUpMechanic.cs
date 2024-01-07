using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMechanic : MonoBehaviour
{
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            gameController.GetComponent<GameController>().Add_BodyParts();

            Destroy(gameObject);
        }
    }
}
