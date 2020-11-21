using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.05f; //標準移動速度

    void Update ()
    {
        //移動処理
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
        {
            speed /= 2; //Shiftキー押下中は移動速度が1/2倍
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
        //移動範囲制限設定
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

        speed = 0.05f; //移動速度初期化（標準移動速度に従う）
    }
}