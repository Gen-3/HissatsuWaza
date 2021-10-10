using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image playerHPGauge;
    [SerializeField] private Image enemyHPGauge;
    [SerializeField] private Image playerWaitGauge;
    [SerializeField] private Image enemyWaitGauge;
    [SerializeField] BattleManager battleManager;
    [SerializeField] PlayerManager player;
    [SerializeField] EnemyManager enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(battleManager.timeCount % player.interval == 0)
        {
            playerWaitGauge.fillAmount = 1f;
        }
        else
        {
            playerWaitGauge.fillAmount = 100f*(battleManager.timeCount % player.interval)/player.interval/100f;

        }

        if (battleManager.timeCount % enemy.interval == 0)
        {
            enemyWaitGauge.fillAmount = 1f;
        }
        else
        {
            enemyWaitGauge.fillAmount = 100f * (battleManager.timeCount % enemy.interval) / enemy.interval / 100f;

        }

        playerHPGauge.fillAmount = 100f * player.hp / player.maxHp / 100f;
        enemyHPGauge.fillAmount = 100f * enemy.hp / enemy.maxHp / 100f;

    }
}
