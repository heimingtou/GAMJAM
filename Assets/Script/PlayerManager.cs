using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int hp;
    public int MaxHp;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        hp = MaxHp;
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Player HP: " + hp);
        if (hp <= 0)
        {
            Die();
        }   
    }
    public void Die()
    {
        Time.timeScale = 0f;    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
