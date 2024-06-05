using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements;

    public Text[] AchievementNameTexts = new Text[4];

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
        AchievementNameTexts[0].text = achievements[0].name;
        AchievementNameTexts[1].text = achievements[0].description;
        AchievementNameTexts[2].text = $"{achievements[0].currentProgress} / {achievements[0].goal}";
        AchievementNameTexts[3].text = achievements[0].isUnlocked ? "달성" : "미달성";
    }

    public void AddProgress(string achievementName, int amount)
    {
        Achievement achievement = achievements.Find( a => a.name == achievementName );
        if( achievement != null)
        {
            achievement.AddProgress(amount);
        }
    }
    public void AddAchievement ( Achievement achievement)
    {
        //Achievement temp = new Achievement("이름", "설명", 5); 
        achievements.Add(achievement);      //List에 업적 추가
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AddProgress("도약" , 1);      //AddProgressInList 로 넣어야하는데요..?
            UpdateAchievementUI();
        }
    }
}
