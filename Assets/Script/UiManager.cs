using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public TextMeshProUGUI CountEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        CountEnemy.text ="/"+ CountEnemies().ToString();
    }
    public int CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        return enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
