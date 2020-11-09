using System;
using System.Threading.Tasks;
using UnityEngine;

public class Tarrot : MonoBehaviour {
    public GameObject center; //円運動の中心になるObject
    public GameObject bulletPrefab; //弾オブジェクトのプレハブ
    private GameObject clone;       //Instantiateされたオブジェクト
    private Bullet bulletScript;    //スクリプトのインスタンス
    private float speed = 60; //円運動速度
    private bool shotFlag = false; //発射中はtrue

    void Update () {
        transform.RotateAround (center.transform.position, transform.forward, speed * Time.deltaTime); //回転

        if (Input.GetKey (KeyCode.LeftArrow) && speed < 0 || Input.GetKey (KeyCode.RightArrow) && speed > 0) speed = -speed;
        if (Input.GetKey (KeyCode.Return)) {
            if(!shotFlag) MakeBullet(5f);
        }
    }

    public async void MakeBullet(float speed)
    {
        shotFlag = true;
        clone = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bulletScript = clone.GetComponent<Bullet>();
        bulletScript.Shot(speed, 0);

        await Task.Delay(100);
        shotFlag = false;
    }

}