using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    public float speed;
    public float min;
    public float max;
    [SerializeField] ParticleSystem KeyFX = null;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {

            case "Player":
                KeyFX.Play();
                FindObjectOfType<AudioManager>().Play("Key");
                Disappear();
                break;
        }
    }
    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
