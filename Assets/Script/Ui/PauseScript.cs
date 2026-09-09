using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : VictoryUI
{
    public Image pauseImage;
    // Start is called before the first frame update
    void Start()
    {
        pauseImage.transform.DOScale(Vector3.zero, 0f);
    }
    public void ShowPauseUI()
    {
        pauseImage.transform.DOScale(Vector3.one, 0f);
        Time.timeScale = 0f;
    }
    public void HidePauseUI()
    {
        pauseImage.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
