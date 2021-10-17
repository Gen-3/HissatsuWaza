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
        Debug.Log($"�Z�^�C�v���u���v�ɂȂ��Ă����OK");

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
            WazaSelect();//�Z�̒��I

            WazaSuccessJudge();//�Z�̐�������

            WazaChainJudge();//�Z�̘A�g����i�U���̌p������j
            yield return new WaitForSecondsRealtime(0.7f);

        }
        yield return new WaitForSecondsRealtime(1.5f);

        Debug.Log($"�_���[�W�̍��v��{totalDamage}�B{unitName}�^�[���G���h�B�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`�`");

        yield return new WaitForSecondsRealtime(0.5f);
        endCalculate = true;
    }

    void WazaSelect()
    {
        Debug.Log("�����_���ɑI�΂��Z�̏d���𔻒肵�܂�");

        turnProgressCount++;
        //�Z�̒��I
        notRepeated = false;
        //�d���̊m�F�Əd�����Ă����ꍇ�̍Ē��I�i�d�����Ȃ��ԍ����o��܂Œ��I�𑱂���j
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
        Debug.Log($"���I���I���܂����B������{R}�ł�");
        //�Z�̗������X�g�ɑI�΂ꂽ�Z��ǉ�����
        wazaHistory.Add(R);
        Debug.Log($"{turnProgressCount}���ڂ̋Z��{wazanameList[wazaHistory[turnProgressCount - 1]]}{wazaTypeSO.wazaTypeName}");
    }

    void WazaSuccessJudge()
    {
        Debug.Log("�Z�̐�����������܂�");

        //�Z�̐�������
        S = Random.Range(0, 100);
        Debug.Log($"��������̗�����{S}�i���̐�����{wazaList[R][0]}���Ⴂ�Ȃ�΍U�������j");
        if (wazaList[R][0] >= S)//�����̏ꍇ�iR�ԖڂɑI�΂ꂽ�Z�̗v�f0�i���������j���Q�Ƃ��Ă���j
        {
            int amount = wazaList[R][1] * wazaTypeSO.zangekiRate / 100 + wazaList[R][2] * wazaTypeSO.sitotsuRate / 100 + wazaList[R][3] * wazaTypeSO.dagekiRate / 100;

            StartCoroutine(PlaySoundCor(0, 0f));
            ShowDamage(amount.ToString());
            target.hp -= amount;

            Debug.Log($"{turnProgressCount}���ځF{wazanameList[R]}{wazaTypeSO.wazaTypeName}!!{target.unitName}��{amount}�̃_���[�W");//���̋Z�̎a��/�h��/�Ō��_���[�W�ƋZ�^�C�v�̌W������Z���ă_���[�W�����߂Ă���
            totalDamage += amount;
        }
        else//���s�̏ꍇ
        {
            StartCoroutine(PlaySoundCor(1, 0f));
            ShowDamage("miss");
            Debug.Log($"player��{wazanameList[R]}{wazaTypeSO.wazaTypeName}�͎��s�����i������{wazaList[R][0]}�����Ő����A��������̗�����{S}�ł����j");
        }
    }

    void WazaChainJudge()
    {
        Debug.Log("�p���̔�������܂�");

        //�Z�̘A�g����i�U���̌p������j
        S = Random.Range(0, 100);
        if (wazaList[R][7] < S)//���s�̏ꍇ
        {
            endTurn = true;
            Debug.Log($"�A�g���s�APlayer�̍U�����I���i�������A�g��{wazaList[R][7]}�����Ő����A�A�g����̗�����{S}�ł����j");
        }
        else
        {
            Debug.Log($"�A�g�����i�������A�g��{wazaList[R][7]}�����Ő����A�A�g����̗�����{S}�ł����j");
        }
        if (wazaHistory.Count >= 7)
        {
            endTurn = true;
            Debug.Log($"7���ڂ܂ŋZ���o���̂�{unitName}�^�[���I���I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I�I");
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