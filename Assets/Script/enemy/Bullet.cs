using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed = 50f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager player= collision.gameObject.GetComponent<PlayerManager>();
        if (player!=null)
        {
            player.TakeDamage(0);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Shoot(GameObject target)
    {
        PlayerManager player= target.GetComponent<PlayerManager>();
        if (player.isHidden)
        {
            return;
        }
       player.TakeDamage(1);

    }
}
