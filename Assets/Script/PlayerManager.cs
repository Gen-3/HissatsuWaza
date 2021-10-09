using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
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


        //for (int wazaNumber = 0; i < 7; i++)
        //{
        //    wazaList[i][]

        //    for (int parameter = 0; j < 8; j++)
        //    {
        //        wazaList[wazaNumber][parameter] =
        //            }



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

    }

    void Update()
    {
        
    }

    public void PlayersTurn()
    {
        //1つ目の技の抽選
        int R = Random.Range(0, 7);
        Debug.Log($"乱数は{R}");
        //このターンに使用した技の履歴リストに選ばれた技を追加する（2つ目以降の技の抽選時に重複を確認するために使う）
        List<int> wazaHistory = new List<int>();
        wazaHistory.Add(R);
        Debug.Log(wazaHistory[0]);

        //1つ目の技の成功判定
        int S = Random.Range(0, 100);
        Debug.Log($"成功判定の乱数は{S}（この数字より成功率が高いと攻撃成功）");
        if (wazaList[R][0]>=S)//成功の場合
        {
            Debug.Log($"1撃目：{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!");
            Debug.Log($"敵に{wazaList[R][1]*wazaTypeSO.zangekiRate/100 + wazaList[R][2]*wazaTypeSO.sitotsuRate/100 + wazaList[R][3]*wazaTypeSO.dagekiRate/100}のダメージ");
        }
        else//失敗の場合
        {
            Debug.Log($"playerの{wazanameList[R]}は失敗した（成功率{wazaList[R][0]}、成功判定の乱数は{S}でした）");
        }

        //技の連携判定（攻撃の継続判定）
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//失敗の場合
        {
            Debug.Log($"Playerの攻撃が終了（連携率{wazaList[R][7]}、連携判定の乱数は{S}でした）");
            return;
        }









        //2つ目の技の抽選
        bool notRepeated = false;
        //重複の確認と重複していた場合の再抽選
        while (!notRepeated)
        {
            Debug.Log("重複の抽選をします");
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
        //このターンに使用した技の履歴リストに選ばれた技を追加する
        wazaHistory.Add(R);
        Debug.Log($"1つ目の技は{wazaHistory[0]}/2つ目の技は{wazaHistory[1]}");

        //2つ目の技の成功判定
        S = Random.Range(0, 100);
        Debug.Log($"成功判定の乱数は{S}（この数字より成功率が高いと攻撃成功）");
        if (wazaList[R][0] >= S)//成功の場合
        {
            Debug.Log($"2撃目：{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!");
            Debug.Log($"敵に{wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100}のダメージ");
        }
        else//失敗の場合
        {
            Debug.Log($"playerの{wazanameList[R]}は失敗した（成功率{wazaList[R][0]}、成功判定の乱数は{S}でした）");
        }

        //技の連携判定（攻撃の継続判定）
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//失敗の場合
        {
            Debug.Log($"Playerの攻撃が終了（連携率{wazaList[R][7]}、連携判定の乱数は{S}でした）");
            return;
        }










        //3つ目の技の抽選
        notRepeated = false;
        //重複の確認と重複していた場合の再抽選
        while (!notRepeated)
        {
            Debug.Log("重複の抽選をします");
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
        //このターンに使用した技の履歴リストに選ばれた技を追加する
        wazaHistory.Add(R);
        Debug.Log($"1つ目の技は{wazaHistory[0]}/2つ目の技は{wazaHistory[1]}/3つ目の技は{wazaHistory[2]}");

        //3つ目の技の成功判定
        S = Random.Range(0, 100);
        Debug.Log($"成功判定の乱数は{S}（この数字より成功率が高いと攻撃成功）");
        if (wazaList[R][0] >= S)//成功の場合
        {
            Debug.Log($"3撃目：{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!");
            Debug.Log($"敵に{wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100}のダメージ");
        }
        else//失敗の場合
        {
            Debug.Log($"playerの{wazanameList[R]}は失敗した（成功率{wazaList[R][0]}、成功判定の乱数は{S}でした）");
        }

        //技の連携判定（攻撃の継続判定）
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//失敗の場合
        {
            Debug.Log($"Playerの攻撃が終了（連携率{wazaList[R][7]}、連携判定の乱数は{S}でした）");
            return;
        }










        //4つ目の技の抽選
        notRepeated = false;
        //重複の確認と重複していた場合の再抽選
        while (!notRepeated)
        {
            Debug.Log("重複の抽選をします");
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
        //このターンに使用した技の履歴リストに選ばれた技を追加する
        wazaHistory.Add(R);
        Debug.Log($"1つ目の技は{wazaHistory[0]}/2つ目の技は{wazaHistory[1]}/3つ目の技は{wazaHistory[2]}/4つ目の技は{wazaHistory[3]}");

        //4つ目の技の成功判定
        S = Random.Range(0, 100);
        Debug.Log($"成功判定の乱数は{S}（この数字より成功率が高いと攻撃成功）");
        if (wazaList[R][0] >= S)//成功の場合
        {
            Debug.Log($"4撃目：{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!");
            Debug.Log($"敵に{wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100}のダメージ");
        }
        else//失敗の場合
        {
            Debug.Log($"playerの{wazanameList[R]}は失敗した（成功率{wazaList[R][0]}、成功判定の乱数は{S}でした）");
        }

        //技の連携判定（攻撃の継続判定）
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//失敗の場合
        {
            Debug.Log($"Playerの攻撃が終了（連携率{wazaList[R][7]}、連携判定の乱数は{S}でした）");
            return;
        }
        Debug.Log("本来は5撃目に続きます");
    }
}
