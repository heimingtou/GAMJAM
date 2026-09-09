using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    public enemyMove enemyScript;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (GameManager.instance.endGame) return;
        PlayerManager playerScript = collision.gameObject.GetComponent<PlayerManager>();
        // wallLayer là Layer của bức tường

        if (playerScript != null)
        {
            if(playerScript.isHidden) return; // Nếu player đang ẩn, không thực hiện hành vi truy đuổi
            enemyScript.Chasing(playerScript);
           
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager playerScript = collision.gameObject.GetComponent<PlayerManager>();
            if(playerScript.isHidden) 
            {
                enemyScript.isShoot = false; // Nếu player đang ẩn, không bắn
                return;
            }
            enemyScript.isShoot = true;
            // (Nâng cao) Nếu tường/ vật cản chắn giữa lính và player, có thể kết hợp Raycast ở đây
            // để kiểm tra xem có bị cản tầm nhìn không.
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyScript.isShoot = false;

            // Cho Enemy quay lại trạng thái tuần tra bình thường
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
