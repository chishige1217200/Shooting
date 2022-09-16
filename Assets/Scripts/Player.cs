using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Die;
    private UIManager _UIManager;
    float speed = 0.05f; //標準移動速度
    public int life = 3;

    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        //移動処理
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed = 0.025f; //Shiftキー押下中は移動速度が1/2倍
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 0.05f; //移動速度初期化（標準移動速度に従う）
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
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            Instantiate(Die);

            Debug.Log("Clash");
            life--;
            if (life == 0)
            {
                _UIManager.ChangeGameOverPanel(); //ゲームオーバー画面の表示
                Destroy(this.gameObject);
            }
        }
    }

    public Vector2 PlayerPosition()
    {
        return new Vector2(this.transform.position.x, this.transform.position.y); //プレイヤーの現在位置をreturn
    }

}