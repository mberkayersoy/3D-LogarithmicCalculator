using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceButton : OperationButtonBase
{
    List<string> operators = new List<string> {"+", "-", "/", "*", "." };
    public override void Operation(List<string> text)
    {
        if (text.Count == 0)
        {

        }
        else if (operators.Contains(text[text.Count - 1]))
        {
            text.RemoveAt(text.Count - 1);
            DisplayText(text);
        }
        else if (text.Count < 3 && (text[0] == "log" || text[0] == "ln"))
        {
            text.Clear();
            DisplayText(text);
        }
        else if (text.Count > 2 && text[text.Count - 1] == "(" && (text[text.Count - 2] == "log" || text[text.Count - 2] == "ln"))
        {
            text.RemoveRange(text.Count - 2, 2);
            DisplayText(text);
        }
        else
        {
            DeleteLastElement(text);
            DisplayText(text);
        }
        /*else if(text[text.Count - 1] != "log" && text[text.Count - 1] != "ln" && text[text.Count - 1].Length > 1)
        {

        }*/
    }
    public void DeleteLastElement(List<string> text)
    {
        string tmp = text[text.Count - 1];
        string tmp2 = tmp.Remove(tmp.Length - 1);
        text.RemoveAt(text.Count - 1);
            
        if (tmp2 == "")
        {

        }
        else
        {
            text.Add(tmp2);
        }
    }

    public override void DisplayText(List<string> text)
    {
        inputManager.screenText = string.Concat(text);
        inputManager.screen.text = inputManager.screenText;
        //screenText = string.Concat(textList);
        //screen.text = screenText;
    }

    public override void Move()
    {
        float locayY = transform.localPosition.y;
        transform.DOLocalMoveY(locayY - 0.1f, 0.15f).SetEase(Ease.OutCubic).OnComplete(() =>
          transform.DOLocalMoveY(locayY, 0.15f).SetEase(Ease.OutCubic));
    }
}
