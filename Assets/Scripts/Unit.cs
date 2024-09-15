using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public float currentHP;

    public int characterIndex;
    private Collider2D collider;

    Animator animator;
    AudioSource AttackAudioSource;

    public bool isMove;
    public bool isEnemy;

    void Start()
    {
        
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        AttackAudioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }

    

    public IEnumerator Attack(Transform enemyPos, Transform playerPos, Animator enemyAnimator, Unit enemyUnit, string animTrigger, AudioClip clip)
    {
        if (isMove)
        {
            animator.SetBool("isRun", true);
            transform.DOMove(new Vector2(enemyPos.position.x , enemyPos.position.y), 2);
            yield return new WaitForSeconds(2);
            animator.SetBool("isRun", false);
            yield return new WaitForSeconds(.5f);
        }
        animator.SetTrigger(animTrigger);
        AttackAudioSource.clip = clip;
        AttackAudioSource.Play();
        enemyAnimator.SetTrigger("Hit");
        yield return new WaitForSeconds(.5f);
        enemyUnit.TakeDamage(damage);
        switch (characterIndex)
        {
            case 0:
                if (enemyUnit.currentHP <= 0)
                {
                    enemyAnimator.SetTrigger("Die");
                    enemyUnit.collider.offset = new Vector2(collider.offset.x, 0.19f);
                    BattleSystem.state = BattleState.WON;
                }
                break;
            case 1:
                if (enemyUnit.currentHP <= 0)
                {
                    enemyAnimator.SetTrigger("Die");
                    enemyUnit.collider.offset = new Vector2(collider.offset.x, 0.67f);
                    BattleSystem.state = BattleState.LOST;
                }
                break;
        }
        yield return new WaitForSeconds(1f);

        if (isMove)
        {
            
            if(isEnemy)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            animator.SetBool("isRun", true);
            if(isEnemy)
            {
                transform.DOMove(new Vector2(playerPos.position.x + 1.6f, playerPos.position.y), 2);
            }
            else
            {
                transform.DOMove(new Vector2(playerPos.position.x - 1.6f, playerPos.position.y), 2);
            }
            yield return new WaitForSeconds(2);
            animator.SetBool("isRun", false);
            if(isEnemy)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
