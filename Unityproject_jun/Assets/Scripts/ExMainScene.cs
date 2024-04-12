using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExMainScene : MonoBehaviour
{
    public Text PointUI;
    // Start is called before the first frame update
    void Start()
    {
        PointUI.text = PlayerPrefs.GetInt("Point").ToString();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene_Shoot");
    }

        

}
