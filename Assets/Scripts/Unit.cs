using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator Attack(Transform enemyPos,Transform playerPos,Animator enemyAnimator)
    {
        animator.SetBool("isRun", true);
        transform.DOMove(new Vector2(enemyPos.position.x - 1.6f,enemyPos.position.y), 2);
        yield return new WaitForSeconds(2);
        animator.SetBool("isRun", false);
        yield return new WaitForSeconds(.5f);
        animator.SetTrigger("Attack");
        enemyAnimator.SetTrigger("Hit");
        yield return new WaitForSeconds(1f);
        animator.SetBool("isRun", true);
        transform.DOMove(playerPos.position, 2);
        yield return new WaitForSeconds(2);
        animator.SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        BattleSystem.state = BattleState.ENEMYTURN;
    }
}
