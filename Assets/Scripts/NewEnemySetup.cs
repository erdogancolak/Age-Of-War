using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NewEnemySetup : MonoBehaviour
{
    public List<GameObject> enemiesPrefab;
    private static int enemyIndex;
    public TMP_Dropdown skillDropdown;
    public static int choosedSkill;
    public List<string> Skills;
    void Start()
    {
        switch (BattleSystem.winIndex)
        {
            case 1:
                Skills.Clear();
                Skills.Add("BotWheel");
                skillDropdown.AddOptions(Skills);
                break;
            case 2:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                skillDropdown.AddOptions(Skills);
                break;
            case 3:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                Skills.Add("Wizard");
                skillDropdown.AddOptions(Skills);
                break;
            case 4:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                Skills.Add("Wizard");
                Skills.Add("Slime");
                skillDropdown.AddOptions(Skills);
                break;
        }

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
            case 3:
                BattleSystem.enemyPrefab = enemiesPrefab[enemyIndex];
                enemyIndex++;
                break;
        }
        SceneManager.LoadScene(2);
    }

    public void SkillButton()
    {
        choosedSkill = skillDropdown.value;
        Debug.Log(choosedSkill);
    }

    public void SkillAdd()
    {
        switch (BattleSystem.winIndex)
        {
            case 1:
                skillDropdown.AddOptions(Skills);
                break;
        }
    }
}
