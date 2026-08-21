using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoHome()
    {
        GameManager.instance.win = false;
        GameManager.instance.lose = false;
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
    public void Retry()
    {
        GameManager.instance.win = false;
        GameManager.instance.lose = false;
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt(UserData.Level));
    }
    public void NextLevel()
    {
        GameManager.instance.win = false;
        GameManager.instance.lose = false;
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        int level = PlayerPrefs.GetInt(UserData.Level) + 1;
        PlayerPrefs.SetInt(UserData.Level, level);
        SceneManager.LoadScene("Level " + level);
    }

}
