using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LnButton : OperationButtonBase
{
    List<string> numbers = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public override void Operation(List<string> text)
    {
        if (text.Count == 0)
        {
            text.Add(value);
            text.Add("(");
            DisplayText(text);
        }
        else if(text[text.Count - 1] == "." || text[text.Count - 1] == ")" || text[text.Count - 1] == "log" || text[text.Count - 1] == "ln")
        {

        }
        else if (text[text.Count - 1].StartsWith("0") || text[text.Count - 1].StartsWith("1") || text[text.Count - 1].StartsWith("2")
            || text[text.Count - 1].StartsWith("3") || text[text.Count - 1].StartsWith("4") || text[text.Count - 1].StartsWith("5")
            || text[text.Count - 1].StartsWith("6") || text[text.Count - 1].StartsWith("7") || text[text.Count - 1].StartsWith("8")
            || text[text.Count - 1].StartsWith("9"))
        {
            text.Add("*");
            text.Add(value);
            text.Add("(");
            DisplayText(text);
        }
        else
        {
            text.Add(value);
            text.Add("(");
            DisplayText(text);
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
