using System;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        TimeOut(5000);
    }

    public void Shot(float speed, float radian)
    {
        float force_x;
        float force_y;
        radian = radian * (float)(Math.PI / 180); //ラジアン(pi)に変換
        force_x = speed * (float)Math.Cos(radian); //x軸方向の力を計算
        force_y = speed * (float)Math.Sin(radian); //z軸方向の力を計算
        rb.AddForce(force_x, force_y, 0, ForceMode.VelocityChange); //瞬間的に弾に力を加える(質量無視)
    }

    async void TimeOut(int time)
    {
        await Task.Delay(time);
        Destroy(this.gameObject);
    }

    /*void OnTriggerEnter()
    {
        Destroy(this.gameObject);
    }*/
    //ゲームタグを指定すること！弾同士が衝突します！
}