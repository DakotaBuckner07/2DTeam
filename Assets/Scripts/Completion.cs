using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    bool finished = false;
    float delay = 3.2f;

    void Update()
    {
        
        if(finished)
        {
            delay -= Time.deltaTime;
            if(delay < 0)
            {
                GameController.Instance.screen = "Select";
                GameController.Instance.OnLoadMenuScene("MainMenu");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You know i dont get executed.");
            finished = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
