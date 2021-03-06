using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().isDead = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
