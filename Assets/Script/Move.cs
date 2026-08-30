using DG.Tweening;
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
    Vector3 pos;
    private Rigidbody2D rb;
    void Start()
    {
        pos = new Vector3(-15.16f, -8.2f, 0);
        this.transform.DOMove(pos, 1f).SetEase(Ease.OutBack);
        speed = GetComponent<PlayerManager>().speed;
        rb= GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.collisionDetectionMode= CollisionDetectionMode2D.Continuous;
            rb.freezeRotation = true; // Khóa xoay vật lý
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (GameManager.instance.endGame) return;
        if (collision.gameObject.CompareTag("Enemy"))
        {
           enemyMove enemy= collision.gameObject.GetComponent<enemyMove>();
            AudioManager.Instance.PlaySFX("fight");
            enemy.die();
            count++;
            Debug.Log("giet enemy");
            if (count==UiManager.Instance.CountEnemies())
            {
                
                GameManager.instance.endGame = true;
                VictoryUI.instance.ShowUI();
            }
            UiManager.Instance.UpdateCountEnemyText(count);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.endGame)
        {
            rb.velocity = Vector2.zero; // Dừng chuyển động khi kết thúc game
            return;
        }
        //HandleMove();
        // Hàm Update cũ có thể xóa hoặc chỉ để bắt sự kiện khác nếu cần, 
        // nhưng với di chuyển vật lý thì đưa hết vào FixedUpdate.
    }



    private void HandleMove()
    {
        Vector2 targetVelocity = Vector2.zero;
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetVelocity = new Vector2(speed, 0);
            checkKey = 0;
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetVelocity = new Vector2(-speed, 0);
            checkKey = 1;
           
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            targetVelocity = new Vector2(0, -speed);
            checkKey = 2;
            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            targetVelocity = new Vector2(0, speed);
            checkKey = 3;
           
        }

        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
        }

        RotateCharacter();
    }

    public void MoveRight()
    {
        Vector2 targetVelocity = Vector2.zero;
        targetVelocity = new Vector2(speed, 0);
        checkKey = 0;
        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
            Debug.Log("MoveRight");
        }
        RotateCharacter();
    }
    public void Moveleft()
    {
        Vector2 targetVelocity = Vector2.zero;
        targetVelocity = new Vector2(-speed, 0);
        checkKey = 1;
        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
            Debug.Log("Moveleft");
        }
        RotateCharacter();
    }
    public void MoveUp()
    {
        Vector2 targetVelocity = Vector2.zero;
        targetVelocity = new Vector2(0,speed);
        checkKey = 3;
        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
            Debug.Log("MoveUp");
        }
        RotateCharacter();
    }
    public void MoveDown()
    {
        Vector2 targetVelocity = Vector2.zero;
        targetVelocity = new Vector2(0,-speed);
        checkKey = 2;
        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
            Debug.Log("MoveDown");
        }
        RotateCharacter();
    }
    public void StopMoving()
    {
        Vector2 targetVelocity = Vector2.zero;
        if (rb != null)
        {
            // Gán trực tiếp velocity để va chạm tường là khựng lại ngay, không bị trượt
            rb.velocity = targetVelocity;
        }
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
