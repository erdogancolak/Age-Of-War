using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image playerHealthBar, enemyHealthBar;
    private GameObject player, enemy;
    private Unit playerUnit, enemyUnit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        playerUnit = player.transform.GetChild(0).GetComponent<Unit>();
        enemyUnit = enemy.transform.GetChild (0).GetComponent<Unit>();  
    }

    private void Update()
    {
        HealthBarController();
    }
    void HealthBarController()
    {
        playerHealthBar.fillAmount = playerUnit.currentHP / 100;
        enemyHealthBar.fillAmount = enemyUnit.currentHP / 100;
    }
}
