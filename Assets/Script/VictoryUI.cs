using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryUI : MonoBehaviour
{
    public static VictoryUI instance;
    // Start is called before the first frame update
     void Start()
    {
        if (instance == null) instance = this;
        this.transform.DOScale(Vector3.zero, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ShowUI()
    {
       this.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        AudioManager.Instance.PlaySFX("Victory");
    }
    public void GoHome()
    {
        GameManager.instance.endGame = false;
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
        AudioManager.Instance.PlaySFX("Click");
    }
    public void Retry()
    {
        GameManager.instance.endGame = false;
        
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        int level = PlayerPrefs.GetInt(UserData.Level);
        SceneManager.LoadScene("Level " + level);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void NextLevel()
    {
        int level = PlayerPrefs.GetInt(UserData.Level) + 1;
        if(level>11)
        {
            return;
        }
        AudioManager.Instance.PlaySFX("Click");
        GameManager.instance.endGame = false;
        GameManager.instance.enemyDie = false;
        Time.timeScale = 1f;
        
        PlayerPrefs.SetInt(UserData.Level, level);
        SceneManager.LoadScene("Level " + level);
    }

}
