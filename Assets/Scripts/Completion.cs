using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    public Collider2D coll;
    bool finished = false;

    void Start()
    {
        //Check if the isTrigger option on th Collider2D is set to true or false
        if (coll.isTrigger)
        {
            Debug.Log("This Collider2D can be triggered");
        }
        else if (!coll.isTrigger)
        {
            Debug.Log("This Collider2D cannot be triggered");
        }
    }

    void Update()
    {
        if(finished) GameController.Instance.OnLoadMenuScene("MainMenu", "Select");
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
