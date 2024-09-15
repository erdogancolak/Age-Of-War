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
            case 5:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                Skills.Add("Wizard");
                Skills.Add("Slime");
                Skills.Add("Demon");
                skillDropdown.AddOptions(Skills);
                break;
            case 6:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                Skills.Add("Wizard");
                Skills.Add("Slime");
                Skills.Add("Demon");
                Skills.Add("Necromancer");
                skillDropdown.AddOptions(Skills);
                break;
            case 7:
                Skills.Clear();
                Skills.Add("BotWheel");
                Skills.Add("NightBorne");
                Skills.Add("Wizard");
                Skills.Add("Slime");
                Skills.Add("Demon");
                Skills.Add("Necromancer");
                Skills.Add("Patron");
                skillDropdown.AddOptions(Skills);
                break;
        }
    }

    void Update()
    {
    }

    public void SetEnemy()
    {
        if (enemyIndex < enemiesPrefab.Count)
        {
            BattleSystem.enemyPrefab = enemiesPrefab[enemyIndex];
            enemyIndex++;
            SceneManager.LoadScene(2);
        }
        else
        {
            // Tüm düþmanlar bittiðinde sahne 4'e geç
            SceneManager.LoadScene(4);
        }
    }

    public void SkillButton()
    {
        choosedSkill = skillDropdown.value;
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
