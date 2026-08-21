using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int hp;
    public int MaxHp;
    public int speed;
    public GameObject hpObj;
    float scaleHp;
  
    // Start is called before the first frame update
    void Start()
    {
        hp = MaxHp;
        scaleHp = hpObj.transform.localScale.x;
        
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Player HP: " + hp);
        if(hp>0)
       { hpObj.transform.localScale = new Vector2(hpObj.transform.localScale.x - ((scaleHp / MaxHp )* damage), hpObj.transform.localScale.y); }
        else
        {
                       hpObj.transform.localScale = new Vector2(0, hpObj.transform.localScale.y);
        }
        if (hp <= 0)
        {
            Die();
        }   
    }
    public void Die()
    {
        GameManager.instance.endGame = true;
        DefeatUI.instance.ShowUI();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
