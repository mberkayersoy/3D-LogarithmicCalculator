using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPButton : OperationButtonBase
{

    List<string> numbers = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public override void Operation(List<string> text)
    {
        if (text.Count == 0)
        {
            text.Add(value);
            DisplayText(text);
        }
        else if (text[text.Count - 1] == "." || text[text.Count - 1] == ")" || numbers.Contains(text[text.Count - 1]))
        {
            
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
