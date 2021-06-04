using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    bool triggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!triggered)
        {
            Debug.Log("Triggered");
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<SpriteRenderer>().color = new Vector4(0,0,0,0);
                triggered = true;
                GameController.Instance.highScore += 1;
            }
        }
    }
}
