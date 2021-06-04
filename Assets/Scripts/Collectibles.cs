using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            GameController.Instance.highScore += 1;
        }
    }
}
