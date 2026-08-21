using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
     int speed;
    int checkKey;
    int count = 0;
    public TextMeshProUGUI text;
    void Start()
    {
        speed= GetComponent<PlayerManager>().speed;
        text.text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           enemyMove enemy= collision.gameObject.GetComponent<enemyMove>();
            AudioManager.Instance.PlaySFX("fight");
            enemy.die();
            count++;
            if(count==UiManager.Instance.CountEnemies())
            {
                Time.timeScale = 0;
            }
            text.text = count.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
            HandleMove();
    }
   
    private void HandleMove()
    {
        if (Input.GetKey(KeyCode.RightArrow) )
        { // bat phim
           
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            
            checkKey = 0;
           

            //x = 1; y = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        { // bat phim
          
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            checkKey = 1;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        { // bat phim
            
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            checkKey = 2;

        }
        else if (Input.GetKey(KeyCode.UpArrow) )
        { // bat phim
           
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            checkKey = 3;

        }
        RotateCharacter();
    }
    private void RotateCharacter()
    {
        switch (checkKey)
        {
            case 0: // Phải
                transform.rotation = Quaternion.Euler(0, 0, 0f);
                break;
            case 1: // Trái
                transform.rotation = Quaternion.Euler(0, 0,180f);
                break;
            case 2: // Xuống
                transform.rotation = Quaternion.Euler(0, 0, -90f);
                break;
            case 3: // Lên
                transform.rotation = Quaternion.Euler(0, 0, 90f);
                break;
        }
    }
}
