using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;

public class DatabaseManager : MonoBehaviour
{
    public DatabaseReference dataRef;
    public DataButton dataList;
    void Start()
    {
        StartCoroutine(Initilizaion());
    }

    private IEnumerator Initilizaion()
    {
        var task = FirebaseApp.CheckAndFixDependenciesAsync();

        while (!task.IsCompleted)
        {
            yield return null;
        }

        if (task.IsCanceled || task.IsFaulted)
        {
            Debug.LogError("Database Error: " + task.Exception);
        }

        var dependencyStatus = task.Result;

        if (dependencyStatus == DependencyStatus.Available)
        {
            dataRef = FirebaseDatabase.DefaultInstance.GetReference("Data");
            Debug.Log("Init completed");
        }
        else
        {
            Debug.LogError("Database Error: ");
        }
    }

    public void Calculations()
    {
        List<string> dataListt = dataList.data;


        for (int i = 0; i < dataListt.Count; i++)
        {
            Debug.Log("datalist: " + dataListt[i]);
            Firebase.Analytics.FirebaseAnalytics.LogEvent("Calculations", "Equations", dataListt[i]);
        }

        //Dictionary<string, object> updateData = new Dictionary<string, object>();

        //updateData["Calculation"] = dataListt;
        //string key = dataRef.Push().Key;

        //dataRef.Child(key).UpdateChildrenAsync(updateData);
    }
}
