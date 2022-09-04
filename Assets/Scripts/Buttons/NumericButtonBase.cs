using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NumericButtonBase : ButtonBase
{
    public override void Operation(List<string> text)
    {
        if (text.Count == 0)
        {
            text.Add(value);
            DisplayText(text);
        }
        else if (text[text.Count - 1] == "log" || text[text.Count - 1] == "ln")
        {
            
        }
        else if(text[text.Count - 1].Any(char.IsDigit) || text[text.Count - 1].EndsWith("."))
        {
            UpdateLastElement(text);
            DisplayText(text);
        }
        else
        {
            text.Add(value);
            DisplayText(text);
        }
       // text.Add(value);
    }

    public override void DisplayText(List<string> text)
    {
        inputManager.screenText = string.Concat(text);
        inputManager.screen.text = inputManager.screenText;
    }
    public void UpdateLastElement(List<string> text)
    {
        string tmp;

        tmp = text[text.Count - 1];
        Debug.Log("tmp: " + tmp);
        tmp += value;
        text.Remove(text[text.Count - 1]);
        text.Add(tmp);
    }

    public override void Move()
    {
        float locayY = transform.localPosition.y;
        transform.DOLocalMoveY(locayY - 0.1f, 0.15f).SetEase(Ease.OutCubic).OnComplete(() =>
          transform.DOLocalMoveY(locayY , 0.15f).SetEase(Ease.OutCubic));
    }
}
