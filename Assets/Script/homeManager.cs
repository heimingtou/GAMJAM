using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homeManager : MonoBehaviour
{
    public Image setting;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(UserData.Level))
        {
            PlayerPrefs.SetInt(UserData.Level, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GotoLevel()
    {
        AudioManager.Instance.PlaySFX("Click");
        int level = PlayerPrefs.GetInt(UserData.Level);
        PlayerPrefs.SetInt(UserData.Level, level);
        SceneManager.LoadScene("Level "+level);

    }
    public void Reset()
    {
        AudioManager.Instance.PlaySFX("Click");
        PlayerPrefs.SetInt(UserData.Level, 1);
        SceneManager.LoadScene("Home");
    }
    public void Close()
    {
        AudioManager.Instance.PlaySFX("Click");
        setting.gameObject.SetActive(false);
    }
    public void Open()
    {
        AudioManager.Instance.PlaySFX("Click");
        setting.gameObject.SetActive(true);
    }

}
