using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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

    bool endTurn;
    int turnProgressCount;
    int R;
    int S;
    List<int> wazaHistory = new List<int>();
    bool notRepeated;
    int totalDamage;


    void Start()
    {
        wazaTypeSO = wazaTypeListSO.wazaTypeSOs[2];
        Debug.Log($"‹Zƒ^ƒCƒv‚ªuŒ•v‚É‚È‚Á‚Ä‚¢‚ê‚ÎOK");

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

    public int EnemyTurn()
    {
        endTurn = false;
        wazaHistory.Clear();
        turnProgressCount = 0;
        totalDamage = 0;

        while (!endTurn)
        {
            WazaSelect();//‹Z‚Ì’Š‘I

            WazaSuccessJudge();//‹Z‚Ì¬Œ÷”»’è

            WazaChainJudge();//‹Z‚Ì˜AŒg”»’èiUŒ‚‚ÌŒp‘±”»’èj
        }

        Debug.Log($"ƒ_ƒ[ƒW‚Ì‡Œv‚Í{totalDamage}Bƒ^[ƒ“ƒGƒ“ƒhB```````````````````````````````````````````````````````````````````````````````````````````````");
        return totalDamage;
    }

    void WazaSelect()
    {
        Debug.Log("ƒ‰ƒ“ƒ_ƒ€‚É‘I‚Î‚ê‚é‹Z‚Ìd•¡‚ğ”»’è‚µ‚Ü‚·");

        turnProgressCount++;
        //‹Z‚Ì’Š‘I
        notRepeated = false;
        //d•¡‚ÌŠm”F‚Æd•¡‚µ‚Ä‚¢‚½ê‡‚ÌÄ’Š‘Iid•¡‚µ‚È‚¢”Ô†‚ªo‚é‚Ü‚Å’Š‘I‚ğ‘±‚¯‚éj
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
        Debug.Log($"’Š‘I‚ªI‚í‚è‚Ü‚µ‚½B—”‚Í{R}‚Å‚·");
        //‹Z‚Ì—š—ğƒŠƒXƒg‚É‘I‚Î‚ê‚½‹Z‚ğ’Ç‰Á‚·‚é
        wazaHistory.Add(R);
        Debug.Log($"{turnProgressCount}Œ‚–Ú‚Ì‹Z‚Í{wazanameList[wazaHistory[turnProgressCount - 1]]}{wazaTypeSO.wazaTypeName}");
    }

    void WazaSuccessJudge()
    {
        Debug.Log("‹Z‚Ì¬Œ÷”»’è‚ğ‚µ‚Ü‚·");

        //‹Z‚Ì¬Œ÷”»’è
        S = Random.Range(0, 100);
        Debug.Log($"¬Œ÷”»’è‚Ì—”‚Í{S}i‚±‚Ì”š‚ª{wazaList[R][0]}‚æ‚è’á‚¢‚È‚ç‚ÎUŒ‚¬Œ÷j");
        if (wazaList[R][0] >= S)//¬Œ÷‚Ìê‡iR”Ô–Ú‚É‘I‚Î‚ê‚½‹Z‚Ì—v‘f0i–½’†—¦j‚ğQÆ‚µ‚Ä‚¢‚éj
        {
            Debug.Log($"{turnProgressCount}Œ‚–ÚF{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!“G‚É{wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100}‚Ìƒ_ƒ[ƒW");//‚»‚Ì‹Z‚ÌaŒ‚/h“Ë/‘ÅŒ‚ƒ_ƒ[ƒW‚Æ‹Zƒ^ƒCƒv‚ÌŒW”‚ğæZ‚µ‚Äƒ_ƒ[ƒW‚ğ‹‚ß‚Ä‚¢‚é
            totalDamage += wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100;
        }
        else//¸”s‚Ìê‡
        {
            Debug.Log($"Enemy‚Ì{wazanameList[R]}{wazaTypeSO.wazaTypeName}‚Í¸”s‚µ‚½i¬Œ÷—¦{wazaList[R][0]}–¢–‚Å¬Œ÷A¬Œ÷”»’è‚Ì—”‚Í{S}‚Å‚µ‚½j");
        }

    }

    void WazaChainJudge()
    {
        Debug.Log("Œp‘±‚Ì”»’è‚ğ‚µ‚Ü‚·");

        //‹Z‚Ì˜AŒg”»’èiUŒ‚‚ÌŒp‘±”»’èj
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//¸”s‚Ìê‡
        {
            endTurn = true;
            Debug.Log($"˜AŒg¸”sAEnemy‚ÌUŒ‚‚ªI—¹i—”‚ª˜AŒg—¦{wazaList[R][7]}–¢–‚Å¬Œ÷A˜AŒg”»’è‚Ì—”‚Í{S}‚Å‚µ‚½j");
        }
        else
        {
            Debug.Log($"˜AŒg¬Œ÷i—”‚ª˜AŒg—¦{wazaList[R][7]}–¢–‚Å¬Œ÷A˜AŒg”»’è‚Ì—”‚Í{S}‚Å‚µ‚½j");
        }
        if (wazaHistory.Count >= 7)
        {
            endTurn = true;
            Debug.Log($"7Œ‚–Ú‚Ü‚Å‹Z‚ªo‚½‚Ì‚Åƒ^[ƒ“I—¹IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
        }

    }
}
