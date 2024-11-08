using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaPesca : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public ShipController shipController;
    // Start is called before the first frame update
    void Start()
    {
        shipController = GetComponent<ShipController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            shipController.ToggleDialogueBubble(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            shipController.ToggleDialogueBubble(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pescar();
        }
    }

    private void Pescar()
    {
        Debug.Log("Tamos pescando");
    }
}
