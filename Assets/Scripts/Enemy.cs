using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int strength; //合計体力
    public int stageCount = 2; //動作ステージ数
    private int nowStage
    {
        get
        {
            return nowStage;
        }
        set
        {
            nowStage = value;
            StageAction(nowStage);
        }
    } //現在実行中のステージ
    public int[] stageStrength; //特定動作中の体力（displayed）
    private UIManager _UIManager;
    public GameObject enemyBullet;
    private IEnumerator DelayCoroutine(float miliseconds, Action action)
    {
        yield return new WaitForSeconds(miliseconds / 1000f);
        action?.Invoke();
    }
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        stageStrength = new int[stageCount];
        for (int i = 0; i < stageCount; i++)
        {
            stageStrength[i] = 10;
        }

        nowStage = 0;

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

    void StageAction(int nowStage)
    {
        if (nowStage == 0)
        {

        }
        if (nowStage == 1)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyBullet")
        {
            Debug.Log("Hit!");
            stageStrength[nowStage]--;
        }
    }

    void GoPosition(float x, float y, float time) //ワールド座標(x, y)にtime秒で移動
    {
        transform.DOMove(new Vector3(x, y, 0), time);
    }
}