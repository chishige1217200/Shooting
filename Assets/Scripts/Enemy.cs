using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int strength; //合計体力
    public int stageCount = 2; //動作ステージ数
    public int nowStage
    {
        get
        {
            return _nowStage;
        }
        set
        {
            _nowStage = value;
            StageAction(_nowStage);
        }
    } //現在実行中のステージ

    private int _nowStage = 0;
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

        stageStrength[0] = 10;
        stageStrength[1] = 50;

        nowStage = 0;
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
            StartCoroutine("Action0");
        }
        if (nowStage == 1)
        {
            StartCoroutine(DelayCoroutine(1000, () =>
            {
                StartCoroutine("Action1");
            }));
        }
    }

    private IEnumerator Action0()
    {
        yield return null;
        yield break;
    }

    private IEnumerator Action1()
    {
        Debug.Log("Start.");
        while (nowStage == 1)
        {
            for (int j = 0; j < 4; j++)
            {
                int a = UnityEngine.Random.Range(0, 46);
                for (int i = 0; i < 4; i++)
                {
                    GameObject bullet = Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
                    ProgramableBullet pb = bullet.GetComponent<ProgramableBullet>();
                    yield return null;
                    pb.Shot(10f, 90 * i + a);
                }
                yield return new WaitForSeconds(0.5f);
            }

            int x = UnityEngine.Random.Range(-4, 5);
            int y = UnityEngine.Random.Range(-4, 5);

            transform.DOMove(new Vector3(x, y, 0), 0.5f);
            yield return new WaitForSeconds(0.5f);
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