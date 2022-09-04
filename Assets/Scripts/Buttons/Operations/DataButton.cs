using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataButton : OperationButtonBase
{
    public List<string> data = new List<string>();
    public DatabaseManager databaseManager;

    private void Start()
    {
      
    }
    public override void DisplayText(List<string> text) { }

    public override void Operation(List<string> text)
    {
//        Firebase.Analytics.FirebaseAnalytics.LogEvent(
//        Firebase.Analytics.FirebaseAnalytics.EventLogin,
//        new Firebase.Analytics.Parameter[] {
//        new Firebase.Analytics.Parameter(
//        Firebase.Analytics.FirebaseAnalytics.ParameterMethod, databaseManager.Calculations())
//  }
//);


        databaseManager.Calculations();
        //for (int i = 0; i < data.Count; i++)
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("SaveData", "Equations", data[i]);
        //}

    }

    public override void Move()
    {
        float locayY = transform.localPosition.y;
        transform.DOLocalMoveY(locayY - 0.1f, 0.15f).SetEase(Ease.OutCubic).OnComplete(() =>
          transform.DOLocalMoveY(locayY, 0.15f).SetEase(Ease.OutCubic));
    }
}
