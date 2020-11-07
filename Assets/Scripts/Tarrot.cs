using System;
using UnityEngine;

public class Tarrot : MonoBehaviour {
    public GameObject center; //円運動の中心になるObject
    float speed = 60; //円運動速度

    void Update () {
        transform.RotateAround (center.transform.position, transform.forward, speed * Time.deltaTime); //回転

        if (Input.GetKey (KeyCode.LeftArrow) && speed < 0 || Input.GetKey (KeyCode.RightArrow) && speed > 0) speed = -speed;
        if (Input.GetKey (KeyCode.Return)) {

        }
    }

}