using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    int hp;
    public int MaxHp;
    public int speed;
    public GameObject hpObj;
    float scaleHp;
    public bool isHidden = false;
   // public Image imageBoster;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("hidden"))
        {
            GameManager.instance.hiddenBoster = true;
            collision.gameObject.SetActive(false);
            //Color color = imageBoster.color;
            //color.a = 1f;
            //imageBoster.color = color;
            Debug.Log("hidden");
        }
    }
    public void hiddenPlayer()
    {
        Debug.Log("hiddening now");
        if (GameManager.instance.hiddenBoster)
        {
            SpriteRenderer spriteRenderer;
            spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a= 0.5f; // Set alpha to 0.5 for transparency
            spriteRenderer.color = color;
            //Color colorImg = imageBoster.color;
            //colorImg.a = 0.5f;
            //imageBoster.color = colorImg;
            Debug.Log("hiddening");
            isHidden = true;
            StartCoroutine(hiddenDelay(3f));
        }
    }
    IEnumerator hiddenDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.hiddenBoster = false;
        SpriteRenderer spriteRenderer;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 1f; // Set alpha to 0.5 for transparency
        spriteRenderer.color = color;
        isHidden = false;
        Debug.Log("hidden false");
    }
    void Start()
    {
        hp = MaxHp;
        scaleHp = hpObj.transform.localScale.x;       
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
       
        if(hp>0)
        {
            float x= hpObj.transform.localScale.x - ((scaleHp / MaxHp )* damage);
            hpObj.transform.localScale = new Vector2(x, hpObj.transform.localScale.y);
        }
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
}
