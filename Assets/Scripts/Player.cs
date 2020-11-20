using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.1f;

    void Update ()
    {
        if (Input.GetKey (KeyCode.W))
        {
            this.transform.position += new Vector3 (0, speed, 0);
        }
        if (Input.GetKey (KeyCode.A))
        {
            this.transform.position -= new Vector3 (speed, 0, 0);
        }
        if (Input.GetKey (KeyCode.S))
        {
            this.transform.position -= new Vector3 (0, speed, 0);
        }
        if (Input.GetKey (KeyCode.D))
        {
            this.transform.position += new Vector3 (speed, 0, 0);
        }
    }
}