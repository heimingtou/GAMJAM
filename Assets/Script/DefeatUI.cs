using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUI : VictoryUI
{
    // Start is called before the first frame update
    public static new DefeatUI instance;
    void Start()
    {
        if (instance == null) instance = this;
        this.transform.DOScale(Vector3.zero, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ShowUI()
    {
        this.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

}
