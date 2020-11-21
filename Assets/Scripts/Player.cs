using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.05f;

    void Update ()
    {
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
        {
            speed /= 2;
        }
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

        if (this.transform.position.y > 4.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 4.5f, this.transform.position.z);
        }
        if (this.transform.position.y < -4.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -4.5f, this.transform.position.z);
        }
        if (this.transform.position.x > 8.5f)
        {
            this.transform.position = new Vector3(8.5f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x < -8.5f)
        {
            this.transform.position = new Vector3(-8.5f, this.transform.position.y, this.transform.position.z);
        }

        speed = 0.05f;
    }
}