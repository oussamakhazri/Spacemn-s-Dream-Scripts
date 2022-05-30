using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public Transform target;
    public float t;
    [SerializeField] ParticleSystem BtnFX = null;



    bool isPlayer;
  


 
    private void FixedUpdate()
    {
        Vector3 a = door.transform.position;
        Vector3 b = target.transform.position;
      

        if (isPlayer && Input.GetKey(KeyCode.E) )

        {
            door.transform.position = Vector3.Lerp(a, b, t);
            BtnFX.Play();
            FindObjectOfType<AudioManager>().Play("ButtonPush");
            FindObjectOfType<AudioManager>().Play("DoorOpen");



        }

        else
            return;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
          
        }
    }



}
