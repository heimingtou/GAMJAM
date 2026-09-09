using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public TextMeshProUGUI CountEnemy;
    int enemyCount;
    public TextMeshProUGUI CountLevel;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        CountEnemy.text ="0"+"/"+ CountEnemies().ToString();
        CountLevel.text ="level "+ PlayerPrefs.GetInt(UserData.CountLevel).ToString();
    }
    public int CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCount= enemies.Length;
        return enemyCount;
    }
    public void UpdateCountEnemyText(int count)
    {
        CountEnemy.text = count.ToString()+"/"+ enemyCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
