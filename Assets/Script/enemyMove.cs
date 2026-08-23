using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public int speed;
    int checkKey=0;
    public LayerMask wallLayer; // Để chọn Layer "Wall" trong Inspector
    private Vector2 direction=Vector2.right;  // Lưu hướng mà nhân vật đang nhìn/đi
    public bool isChasing = false;
    public Bullet bullet;
    float countdown; // Thời gian giữa các lần bắn
    public bool isShoot = false;                               // 
    public Sprite dieImg;
    bool isLiving=true;
    
    void Start()
    {
       
        player= GameObject.FindGameObjectWithTag("Player");
        countdown = GameManager.instance.countdown;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Move playerScript = collision.gameObject.GetComponent<Move>();
    //    // wallLayer là Layer của bức tường
        
    //    if (playerScript != null)
    //    {
    //        // Bắn Raycast từ vị trí quái đến vị trí player
    //        Vector2 directionToPlayer = (player.position - transform.position).normalized;
    //        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    //        // wallLayer là Layer của bức tường
    //        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, wallLayer);
    //        if(hit.collider!=null){
    //            StopRun();
    //        }
    //        else{
    //            speed = 4;
    //            isChasing = true;
    //        }
    //        Debug.Log("duoi");
    //    }
    //}
    public void Chasing(Move playerScript)
    {
        // wallLayer là Layer của bức tường
       
        if (playerScript != null)
        {
            // Bắn Raycast từ vị trí quái đến vị trí player
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // wallLayer là Layer của bức tường
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, wallLayer);
            if (hit.collider != null)
            {
                StopRun();
            }
            else
            {
                speed = 7;
                isChasing = true;
            }
            Debug.Log("duoi");
        }
    }
    public void die()
    {
        GameManager.instance.Enemydie();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dieImg;
        speed = 0;
        isLiving = false;
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
        UnityEngine.Rendering.Universal.Light2D enemyLight = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        if (enemyLight != null)
        {
            enemyLight.enabled = false; // Tắt đèn khi chết
        }
        this.transform.DOScale(Vector3.zero, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.endGame)
        {
            return;
        }
        if (!isLiving)
            return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.8f, wallLayer);
        Debug.DrawRay(transform.position, direction * 5f, Color.red);
        if (isShoot)
        {
            if ((countdown < 0.05f))
            {
                countdown += Time.deltaTime;
            }
            else
            {
                player.GetComponent<PlayerManager>().TakeDamage(1);
                countdown = 0;
                AudioManager.Instance.PlaySFX("shoot");
            }
        }
        if (GameManager.instance.enemyDie)
        {
            Debug.Log("co ng bi die");
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)directionToPlayer * speed * Time.deltaTime;
            Debug.Log("speed enemy: " + speed);
            speed = 7;
            // Cập nhật hướng để Raycast (nếu vẫn muốn né tường khi đuổi)
            direction = directionToPlayer;
            LookAtPlayer(directionToPlayer);
           
            
            if(hit.collider!=null)
            {
                isShoot = false;
                StopRun();
            }
        }
        else
        {
            if (hit.collider != null)
            {
                checkKey = Random.Range(0, 4);
                Debug.Log(checkKey);
                speed = 2;
            }
            else
            { HandleMove(); }
            RotateCharacter();
        }
       
        

    }
    void StopRun()
    {
        isChasing = false;
        GameManager.instance.enemyDie = false;
        speed = 2;
    }
    private void LookAtPlayer(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // -90 là để bù trừ nếu Sprite gốc của ông quay lên trên
        transform.rotation = Quaternion.Euler(0, 0, angle );
    }
    private void HandleMove()
    {
        if (checkKey == 0)
        { // bat phim

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            
            


            //x = 1; y = 0;
        }
        else if (checkKey == 1)
        { // bat phim

            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            

        }
        else if (checkKey == 2)
        { // bat phim

            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            

        }
        else if (checkKey == 3)
        { // bat phim

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            

        }

       
    }
    private void RotateCharacter()
    {
        switch (checkKey)
        {
            case 0: // Phải
               { transform.rotation = Quaternion.Euler(0, 0, 0f);
                    direction = Vector2.right;
                }
                break;
            case 1: // Trái
                { transform.rotation = Quaternion.Euler(0, 0, 180f);
                    direction = Vector2.left;
                }
                break;
            case 2: // Xuống
               { transform.rotation = Quaternion.Euler(0, 0, -90f);
                    direction = Vector2.down;
                }
                break;
            case 3: // Lên
               { transform.rotation = Quaternion.Euler(0, 0, 90f);
                    direction = Vector2.up;
                }
                break;
        }
    }
}
