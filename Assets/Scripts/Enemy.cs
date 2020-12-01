using System;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int strength; //合計体力
    public int stageCount = 2; //動作ステージ数
    private int nowStage = 0; //現在実行中のステージ
    public int[] stageStrength; //特定動作中の体力（displayed）
    private UIManager _UIManager;

    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        stageStrength = new int[stageCount];
        stageStrength[0] = 10;
        stageStrength[1] = 10;
        //GoPosition(-1, 0, 5);
    }

    void Update()
    {
        if (stageStrength[nowStage] == 0)
        {
            nowStage++; //そのステージの体力がなくなったら次のステージへ
            GoPosition(1, 0, 1); //初期位置に復帰
        }
        if (nowStage == stageCount)
        {
            _UIManager.ChangeGameClearPanel(); //ゲームクリア画面の表示
            Destroy(this.gameObject); //最終ステージをクリアしたらDestroy
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyBullet")
            Debug.Log("Hit!");
        stageStrength[nowStage]--;
    }

    void GoPosition(float x, float y, float time) //ワールド座標(x, y)にtime秒で移動
    {
        transform.DOMove(new Vector3(x, y, 0), time);
    }
}