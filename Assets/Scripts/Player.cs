using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform start;
    private Vector2 spawn;
    private Vector2 position;
    private bool isDead = false;
    void Start()
    {
        spawn.x = start.position.x;
        spawn.y = start.position.y + 4;
        position = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            position = spawn;
            isDead = false;
        }
    }
}
