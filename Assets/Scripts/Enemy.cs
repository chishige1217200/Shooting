using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int strength; //合計体力
    public int stageCount = 2; //動作ステージ数
    private int nowStage = 0; //現在実行中のステージ
    public int[] stageStrength; //特定動作中の体力（displayed）

    void Start()
    {
        stageStrength = new int[stageCount];
        stageStrength[0] = 100;
        stageStrength[1] = 100;
    }

    void Update()
    {
        if (stageStrength[nowStage] == 0) nowStage++; //そのステージの体力がなくなったら次のステージへ
        if (nowStage == stageCount) Destroy(this.gameObject); //最終ステージをクリアしたらDestroy
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyBullet")
            Debug.Log("Hit!");
        stageStrength[nowStage]--;
    }
}