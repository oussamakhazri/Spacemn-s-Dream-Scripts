using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithKeys : MonoBehaviour
{
    [SerializeField] GameObject key;
    public GameObject door;
    public Transform target;
    public float t;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !key.activeSelf)
        {
            Vector3 a = door.transform.position;
            Vector3 b = target.transform.position;
            door.transform.position = Vector3.Lerp(a, b, t);
            FindObjectOfType<AudioManager>().Play("DoorOpen");
            //  FindObjectOfType<AudioManager>().Play("Door Open");
        }

        //  else
        {
           // FindObjectOfType<AudioManager>().Play("Door Closed");
        }
    }
}
