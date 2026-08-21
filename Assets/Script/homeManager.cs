using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeManager : MonoBehaviour
{
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
        if(level>=4)
        {
            level = 4;
        }
        PlayerPrefs.SetInt(UserData.Level, level);
        SceneManager.LoadScene("Level "+level);

    }

}
