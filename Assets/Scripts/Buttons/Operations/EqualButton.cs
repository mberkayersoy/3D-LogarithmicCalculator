using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualButton : OperationButtonBase
{
    public InfixConverter infixConverter;
    public DataButton data;
    public RecordButton record;
    public LogButton logButton;
    string mergeText;
    double result;
    List<string> operators = new List<string> { "+", "-", "/", "*", "." };

    public override void Operation(List<string> text)
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
  Firebase.Analytics.FirebaseAnalytics.EventLogin,
  new Firebase.Analytics.Parameter[] {
    new Firebase.Analytics.Parameter(
      Firebase.Analytics.FirebaseAnalytics.ParameterMethod, "1516"),
  }
);
        mergeText = string.Concat(text);
        if (text.Contains("log") || text.Contains("ln"))
        {
            if (record.isRecording)
            {
                logButton.LogCalc(text);
                Debug.Log("Result: " + logButton.LogCalc(text));
                result = logButton.LogCalc(text);
                text.Add(value);
                text.Add(result.ToString());
                data.data.Add(mergeText + value + result.ToString());
                text.RemoveRange(0, text.Count - 1);
                DisplayText(text);
                if (text[text.Count - 1].Contains(","))
                {
                    Debug.Log("FOUND COMA");
                    string tmp = text[text.Count - 1].Replace(',', '.');
                    text.Clear();
                    text.Add(tmp);
                    DisplayText(text);
                }
            }
            else
            {
                logButton.LogCalc(text);
                Debug.Log("Result: " + logButton.LogCalc(text));
                text.Add(logButton.LogCalc(text).ToString());
                text.RemoveRange(0, text.Count - 1);
                DisplayText(text);
                if (text[text.Count - 1].Contains(","))
                {
                    Debug.Log("FOUND COMA");
                    string tmp = text[text.Count - 1].Replace(',', '.');
                    text.Clear();
                    text.Add(tmp);
                    DisplayText(text);
                }
            }
        }
        else
        {
            //mergeText = string.Concat(text);
            if (mergeText.Length != 0 && !operators.Contains(text[text.Count - 1]))
            {
                if (record.isRecording)
                {
                    infixConverter.infixToPostfix(text);
                    result = infixConverter.evaluatePostfix(infixConverter.infixToPostfix(text));
                    text.Add(value);
                    data.data.Add(mergeText + value + result.ToString());
                    text.Add(result.ToString());
                    text.RemoveRange(0, text.Count - 1);
                    DisplayText(text);

                    if (text[text.Count - 1].Contains(","))
                    {
                        Debug.Log("FOUND COMA");
                        string tmp = text[text.Count - 1].Replace(',', '.');
                        text.Clear();
                        text.Add(tmp);
                        DisplayText(text);
                    }
                }
                else
                {
                    infixConverter.infixToPostfix(text);
                    Debug.Log("mergetext: " + mergeText);
                    Debug.Log("infix to postfix:" + infixConverter.infixToPostfix(text));
                    //foreach (var item in text)
                    //{
                    //    Debug.Log(item.ToString());
                    //}
                    Debug.Log("Result: " + infixConverter.evaluatePostfix(infixConverter.infixToPostfix(text)));
                    result = infixConverter.evaluatePostfix(infixConverter.infixToPostfix(text));
                    text.Add(value);
                    text.Add(result.ToString());
                    text.RemoveRange(0, text.Count - 1);
                    DisplayText(text);

                    if (text[text.Count - 1].Contains(","))
                    {
                        Debug.Log("FOUND COMA");
                        string tmp = text[text.Count - 1].Replace(',', '.');
                        text.Clear();
                        text.Add(tmp);
                        DisplayText(text);
                    }
                }
            }
        }
    }
    public override void DisplayText(List<string> text)
    {
        inputManager.screenText = string.Concat(text);
        inputManager.screen.text = inputManager.screenText;
    }

    public override void Move()
    {
        float locayY = transform.localPosition.y;
        transform.DOLocalMoveY(locayY - 0.1f, 0.15f).SetEase(Ease.OutCubic).OnComplete(() =>
          transform.DOLocalMoveY(locayY, 0.15f).SetEase(Ease.OutCubic));
    }
}
