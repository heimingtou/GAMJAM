using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    public enemyMove enemyScript;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        Move playerScript = collision.gameObject.GetComponent<Move>();
        // wallLayer là Layer của bức tường

        if (playerScript != null)
        {
           enemyScript.Chasing(playerScript);
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
