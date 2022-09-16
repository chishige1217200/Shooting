using System;
using System.Collections;
using UnityEngine;

public class ProgramableBullet : MonoBehaviour
{
    Rigidbody2D rb;
    private IEnumerator DelayCoroutine(float miliseconds, Action action)
    {
        yield return new WaitForSeconds(miliseconds / 1000f);
        action?.Invoke();
    }
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        Invoke("TimeOut", 5);
    }

    void TimeOut()
    {
        Destroy(this.gameObject);
    }

    public void Shot(Action a)
    {
        StartCoroutine(DelayCoroutine(0, a));
    }

    public void Shot(float speed, float radian)
    {
        float force_x;
        float force_y;
        radian = radian * (float)(Math.PI / 180); //ラジアン(pi)に変換
        force_x = speed * (float)Math.Cos(radian); //x軸方向の力を計算
        force_y = speed * (float)Math.Sin(radian); //z軸方向の力を計算
        rb.AddForce(new Vector2(force_x, force_y), ForceMode2D.Impulse); //瞬間的に弾に力を加える(質量無視)
    }
}
