using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public bool enemyDie = false; // Variable to track if the enemy is dead
    public bool endGame = false; // Variable to track if the player has won
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Assign the instance to this object
    }
    public void Enemydie()
    {
        enemyDie = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
