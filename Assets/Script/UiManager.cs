using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public TextMeshProUGUI CountEnemy;
    public TextMeshProUGUI CountEnemyText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        CountEnemy.text ="/"+ CountEnemies().ToString();
        CountEnemyText.text = "0";
    }
    public int CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        return enemies.Length;
    }
    public void UpdateCountEnemyText(int count)
    {
        CountEnemyText.text = count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
