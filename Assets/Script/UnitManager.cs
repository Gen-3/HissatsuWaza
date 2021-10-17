using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    [SerializeField] UnitManager target;
    [SerializeField] string unitName;

    public int maxHp;
    public int hp;
    public int interval;
    public WeaponListSO weaponListSO;
    public WeaponSO weaponSO;
    public WazaTypeListSO wazaTypeListSO;
    public WazaTypeSO wazaTypeSO;
    public WazaNameListSO wazaNameListSO;
    public string waza1Name;
    public string waza2Name;
    public string waza3Name;
    public string waza4Name;
    public string waza5Name;
    public string waza6Name;
    public string waza7Name;
    public string[] wazanameList = new string[7];
    public int[] waza1 = new int[8];
    public int[] waza2 = new int[8];
    public int[] waza3 = new int[8];
    public int[] waza4 = new int[8];
    public int[] waza5 = new int[8];
    public int[] waza6 = new int[8];
    public int[] waza7 = new int[8];
    public int[][] wazaList = new int[7][];

    public bool endTurn;
    public bool endCalculate;
    int turnProgressCount;
    int R;
    int S;
    List<int> wazaHistory = new List<int>();
    bool notRepeated;
    int totalDamage;

    public AudioManager audioManager;

    [SerializeField]
    private GameObject uICanvus;
    [SerializeField]
    private GameObject damageText;
    [SerializeField]
    private GameObject targetPosition;
    [SerializeField]
    private Vector3 adjustPosition;


    void Start()
    {
        wazaTypeSO = wazaTypeListSO.wazaTypeSOs[2];
        Debug.Log($"技タイプが「剣」になっていればOK");

        waza1 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza2 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza3 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza4 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza5 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza6 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };
        waza7 = new int[] { Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) };

        wazaList[0] = waza1;
        wazaList[1] = waza2;
        wazaList[2] = waza3;
        wazaList[3] = waza4;
        wazaList[4] = waza5;
        wazaList[5] = waza6;
        wazaList[6] = waza7;

        waza1Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza2Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza3Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza4Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza5Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza6Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        waza7Name = wazaNameListSO.wazaList[Random.Range(0, wazaNameListSO.wazaList.Count)];
        wazanameList[0] = waza1Name;
        wazanameList[1] = waza2Name;
        wazanameList[2] = waza3Name;
        wazanameList[3] = waza4Name;
        wazanameList[4] = waza5Name;
        wazanameList[5] = waza6Name;
        wazanameList[6] = waza7Name;

        hp = maxHp;
    }

    public void StartTurn()
    {
        StartCoroutine("StartTurnCor");
    }

    IEnumerator StartTurnCor()
    {
        endTurn = false;
        wazaHistory.Clear();
        turnProgressCount = 0;
        totalDamage = 0;

        while (!endTurn)
        {
            WazaSelect();//技の抽選

            WazaSuccessJudge();//技の成功判定

            WazaChainJudge();//技の連携判定（攻撃の継続判定）
            yield return new WaitForSecondsRealtime(0.7f);

        }
        yield return new WaitForSecondsRealtime(1.5f);

        Debug.Log($"ダメージの合計は{totalDamage}。{unitName}ターンエンド。〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜〜");

        yield return new WaitForSecondsRealtime(0.5f);
        endCalculate = true;
    }

    void WazaSelect()
    {
        Debug.Log("ランダムに選ばれる技の重複を判定します");

        turnProgressCount++;
        //技の抽選
        notRepeated = false;
        //重複の確認と重複していた場合の再抽選（重複しない番号が出るまで抽選を続ける）
        while (!notRepeated)
        {
            notRepeated = true;
            R = Random.Range(0, 7);
            foreach (int history in wazaHistory)
            {
                if (R == history)
                {
                    notRepeated = false;
                }
            }
        }
        Debug.Log($"抽選が終わりました。乱数は{R}です");
        //技の履歴リストに選ばれた技を追加する
        wazaHistory.Add(R);
        Debug.Log($"{turnProgressCount}撃目の技は{wazanameList[wazaHistory[turnProgressCount - 1]]}{wazaTypeSO.wazaTypeName}");
    }

    void WazaSuccessJudge()
    {
        Debug.Log("技の成功判定をします");

        //技の成功判定
        S = Random.Range(0, 100);
        Debug.Log($"成功判定の乱数は{S}（この数字が{wazaList[R][0]}より低いならば攻撃成功）");
        if (wazaList[R][0] >= S)//成功の場合（R番目に選ばれた技の要素0（＝命中率）を参照している）
        {
            int amount = wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100;

            StartCoroutine(PlaySoundCor(0, 0f));
            ShowDamage(amount.ToString());
            target.hp -= amount;

            Debug.Log($"{turnProgressCount}撃目：{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!{target.unitName}に{amount}のダメージ");//その技の斬撃/刺突/打撃ダメージと技タイプの係数を乗算してダメージを求めている
            totalDamage += amount;
        }
        else//失敗の場合
        {
            StartCoroutine(PlaySoundCor(1, 0f));
            ShowDamage("miss");
            Debug.Log($"playerの{wazanameList[R]}{wazaTypeSO.wazaTypeName}は失敗した（成功率{wazaList[R][0]}未満で成功、成功判定の乱数は{S}でした）");
        }
    }

    void WazaChainJudge()
    {
        Debug.Log("継続の判定をします");

        //技の連携判定（攻撃の継続判定）
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//失敗の場合
        {
            endTurn = true;
            Debug.Log($"連携失敗、Playerの攻撃が終了（乱数が連携率{wazaList[R][7]}未満で成功、連携判定の乱数は{S}でした）");
        }
        else
        {
            Debug.Log($"連携成功（乱数が連携率{wazaList[R][7]}未満で成功、連携判定の乱数は{S}でした）");
        }
        if (wazaHistory.Count >= 7)
        {
            endTurn = true;
            Debug.Log($"7撃目まで技が出たので{unitName}ターン終了！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！");
        }

    }

    public void ShowDamage(string damageAmountOrText)
    {
        GameObject _damageText = Instantiate(damageText, uICanvus.transform);
        _damageText.GetComponent<Text>().text = damageAmountOrText;
        _damageText.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetPosition.transform.position + adjustPosition);
    }

    IEnumerator PlaySoundCor(int id, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioManager.audioSource.PlayOneShot(audioManager.clipList[id]);
    }

}