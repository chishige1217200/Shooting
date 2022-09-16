using System;
using System.Collections;
using UnityEngine;

public class Tarrot : MonoBehaviour
{
    public GameObject center; //円運動の中心になるObject
    public GameObject bulletPrefab; //弾オブジェクトのプレハブ
    private GameObject clone; //Instantiateされたオブジェクト
    private Bullet bulletScript; //スクリプトのインスタンス
    private float speed = 60; //円運動速度
    private bool shotFlag = false; //発射中はtrue
    private IEnumerator DelayCoroutine(float miliseconds, Action action)
    {
        yield return new WaitForSeconds(miliseconds / 1000f);
        action?.Invoke();
    }
    void Update()
    {
        float z;
        transform.RotateAround(center.transform.position, transform.forward, speed * Time.deltaTime); //回転
        z = this.transform.localEulerAngles.z; //タロット回転角度取得
        //Debug.Log(z);
        if (Input.GetKey(KeyCode.X) && speed < 0 || Input.GetKey(KeyCode.C) && speed > 0) speed = -speed; //回転方向反転
        if (Input.GetKey(KeyCode.Z)) if (!shotFlag) MakeBullet(10f, z); //弾発射
    }

    public void MakeBullet(float speed, float radian)
    {
        shotFlag = true; //連射防止
        clone = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity); //弾オブジェクトをクローン
        bulletScript = clone.GetComponent<Bullet>(); //スクリプト情報取得
        bulletScript.Shot(speed, radian); //発射方向に力を加える

        StartCoroutine(DelayCoroutine(100, () =>
        {
            shotFlag = false; //連射防止
        }));
    }
}