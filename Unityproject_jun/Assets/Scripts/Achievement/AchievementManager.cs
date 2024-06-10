using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements;

    public Text[] AchievementTexts = new Text[4];

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateAchievementUI()
    {
        AchievementTexts[0].text = achievements[0].name;
        AchievementTexts[1].text = achievements[0].description;
        AchievementTexts[2].text = $"{achievements[0].currentProgress} / {achievements[0].goal}";
        AchievementTexts[3].text = achievements[0].isUnlocked ? "�޼�" : "�̴޼�";
    }

    public void AddProgressInList(string achievementName, int amount)
    {
        Achievement achievement = achievements.Find( a => a.name == achievementName );
        if( achievement != null)
        {
            achievement.AddProgress(amount);
        }
    }
    public void AddAchievement ( Achievement achievement)
    {
        //Achievement temp = new Achievement("�̸�", "����", 5); 
        achievements.Add(achievement);      //List�� ���� �߰�
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgressInList("����" , 1);      //AddProgressInList �� �־���ϴµ���..?
            UpdateAchievementUI();
        }
    }
}
