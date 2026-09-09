using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BosterHiddenUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                Button mybutton= GetComponent<Button>();
                mybutton.onClick.AddListener(playerManager.hiddenPlayer);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.hiddenBoster)
        {
            Color color = gameObject.GetComponent<Button>().image.color;
            color.a = 1f;
            gameObject.GetComponent<Button>().image.color = color;
        }
        else
        {
            Color color = gameObject.GetComponent<Button>().image.color;
            color.a = 0.5f;
            gameObject.GetComponent<Button>().image.color = color;
        }
    }
}
