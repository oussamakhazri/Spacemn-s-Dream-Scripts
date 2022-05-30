using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{
    private GameObject currentPortal;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (currentPortal != null)
            {
                transform.position = currentPortal.GetComponent<Portal>().GetDestination().position;
                FindObjectOfType<AudioManager>().Play("Teleport");
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Portal"))
        {
            currentPortal = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

      
        if (collision.CompareTag("Portal"))
        {
            if (collision.gameObject == currentPortal)
            {
                currentPortal = null;
            }

        }

    }
}
