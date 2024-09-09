using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewEnemySetup : MonoBehaviour
{
    public List<GameObject> enemiesPrefab;
    private static int enemyIndex;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetEnemy()
    {
        switch (enemyIndex)
        {
            case 0:
                BattleSystem.enemyPrefab = enemiesPrefab[enemyIndex];
                enemyIndex++;
                break;
            case 1:
                BattleSystem.enemyPrefab = enemiesPrefab[enemyIndex];
                enemyIndex++;
                break;
            case 2:
                BattleSystem.enemyPrefab = enemiesPrefab[enemyIndex];
                enemyIndex++;
                break;
        }
        SceneManager.LoadScene(1);
    }
}
