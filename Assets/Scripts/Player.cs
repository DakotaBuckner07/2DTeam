using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform start;
    public bool isDead = false;
    private Vector2 spawn;

    void Start()
    {
        spawn.x = start.position.x;
        spawn.y = start.position.y + 1f;
        transform.position = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            transform.position = spawn;
            isDead = false;
        }
    }
}
