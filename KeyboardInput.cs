using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FinalProject

public class KeyboardInput : MonoBehaviour
{
    public Hero Hero;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Hero.Move(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Hero.Move(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Hero.Move(new Vector2(1, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Hero.Move(new Vector2(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hero.Shoot();
        }
    }
}
