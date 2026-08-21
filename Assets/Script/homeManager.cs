using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(UserData.Level))
        {
            PlayerPrefs.SetInt(UserData.Level, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GotoLevel()
    {
        int level = PlayerPrefs.GetInt(UserData.Level)+1;
        SceneManager.LoadScene("Level "+level);

    }

}
