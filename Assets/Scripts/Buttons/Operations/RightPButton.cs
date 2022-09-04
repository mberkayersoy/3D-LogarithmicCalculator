using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPButton : OperationButtonBase
{

    public override void Operation(List<string> text)
    {
        if (text.Count == 0)
        {
            Debug.Log("text is empty.");
        }
        else if (text[text.Count - 1] == "." || text[text.Count - 1] == "+" || text[text.Count - 1] == "-"
            || text[text.Count - 1] == "*" || text[text.Count - 1] == "/" || text[text.Count - 1] == "log" || text[text.Count - 1] == "ln")
        {
            Debug.Log("last element . + * / -");
        }
        else
        {
            text.Add(value);
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
