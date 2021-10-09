using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int timeCount=0;
    public bool timeGoesBy=true;
    [SerializeField]PlayerManager player;
    [SerializeField]EnemyManager enemy;

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
        player.PlayersTurn();
        yield return new WaitForSeconds(3f);
        Debug.Log("playerTurn終了");
        timeGoesBy = true;

    }
    IEnumerator EnemyTurn()
    {
        Debug.Log("enemyのターン");
        yield return new WaitForSeconds(3f);
        Debug.Log("EnemyTurn終了");
        timeGoesBy = true;

    }
}
