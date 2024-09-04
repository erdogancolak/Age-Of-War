using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using DG.Tweening;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private Animator playerAnimator;
    private Animator enemyAnimator;

    Unit playerUnit;
    Unit enemyUnit;

    public static BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();
        if (playerUnit == null)
        {
            Debug.LogError("Player Unit component is missing on playerPrefab.");
            yield break;
        }

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();
        if (enemyUnit == null)
        {
            Debug.LogError("Enemy Unit component is missing on enemyPrefab.");
            yield break;
        }

        playerAnimator = playerUnit.GetComponent<Animator>();
        enemyAnimator = enemyUnit.GetComponent<Animator>();

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
    }

    IEnumerator PlayerAttack()
    {
        if (state == BattleState.PLAYERTURN)
        {
            yield return StartCoroutine(playerUnit.Attack(enemyBattleStation, playerBattleStation, enemyAnimator));
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
            yield return new WaitForSeconds(0.3f);

            if (isDead)
            {
               enemyAnimator.SetTrigger("Die");
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                yield return StartCoroutine(EnemyTurn());
            }
        }
    }

    IEnumerator EnemyTurn()
    {
        if (state == BattleState.ENEMYTURN)
        {
            yield return StartCoroutine(enemyUnit.Attack(playerBattleStation, enemyBattleStation, playerAnimator));
            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
            yield return new WaitForSeconds(0.3f);



            if (isDead)
            {
                playerAnimator.SetTrigger("Die");
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
            }
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("You won the battle!");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("You were defeated.");
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }
}
