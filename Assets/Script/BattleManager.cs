using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int timeCount=0;
    public bool timeGoesBy=true;
    [SerializeField]PlayerManager player;
    [SerializeField]EnemyManager enemy;
/*    public UIManager uIManager;
    [SerializeField] DamageTextGenerator damageTextGenerator;
*/
    void Start()
    {


    }

    void Update()
    {
        if (timeGoesBy)
        {
            timeCount++;
        }
        // Debug.Log(timeCount);
        if (timeCount % player.interval == 0 && timeGoesBy)
        {
            timeGoesBy = false;
            StartCoroutine("PlayerTurn");
        }
        if (timeCount % enemy.interval == 0 && timeGoesBy)
        {
            timeGoesBy = false;
            StartCoroutine("EnemyTurn");
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("playerのターン");

        player.endCalculate = false;
        player.PlayerTurn();
        yield return new WaitUntil(()=>player.endCalculate==true) ;

        Debug.Log("playerTurn終了");
        if (enemy.hp <= 0)
        {
            Debug.Log("決着");
        }
        else
        {
            timeGoesBy = true;
        }
    }
    IEnumerator EnemyTurn()
    {
        Debug.Log("enemyのターン");

        enemy.endCalculate = false;
        enemy.EnemyTurn();
        yield return new WaitUntil(() => enemy.endCalculate == true);

        Debug.Log("EnemyTurn終了");
        if (player.hp <= 0)
        {
            Debug.Log("決着");
        }
        else
        {
            timeGoesBy = true;
        }
    }
}
