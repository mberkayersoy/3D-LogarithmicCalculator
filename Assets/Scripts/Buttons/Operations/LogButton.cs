using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class LogButton : OperationButtonBase
{
    List<string> numbers = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    string operators;
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
        else if (text[text.Count - 1].Any(char.IsDigit) && !text[text.Count - 1].EndsWith("."))
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

    public float LogCalc(List<string> text)
    {
        text.RemoveAll(item => item == ")");
        Stack<float> stack = new Stack<float>();
        for (int i = 0; i < text.Count; i++)
        {
            string c = text[i];
            if (c == "")
            {
                continue;
            }

            else if (c == "log")
            {
                Debug.Log("c: " + c);
                i++;
                c = text[i];
                Debug.Log("c: " + c);
                if (c == "(")
                {
                    i++;
                    c = text[i];

                    float tmp = float.Parse(c, CultureInfo.InvariantCulture);
                    Debug.Log("before: " + tmp);
                    tmp = Mathf.Log10(tmp);
                    Debug.Log("after: " + tmp);
                    stack.Push(tmp);
                }
            }
            else if (c == "ln")
            {
                Debug.Log("c: " + c);
                i++;
                c = text[i];
                Debug.Log("c: " + c);
                if (c == "(")
                {
                    i++;
                    c = text[i];

                    float tmp = float.Parse(c, CultureInfo.InvariantCulture);
                    Debug.Log("before: " + tmp);
                    tmp = Mathf.Log(tmp);
                    Debug.Log("after: " + tmp);
                    stack.Push(tmp);
                }
            }
            else if (c.Any(char.IsDigit))
            {
                //Debug.Log("c:" + c);
                //double n = 0;

                //// extract the characters and 
                //// store it in num 
                //while (char.IsDigit(c))
                //{
                //    n = n * 10 + (double)(c - '0');
                //    Debug.Log("n: " + n);
                //    i++;
                //    c = exp[i];
                //}
                //i--;

                // push the number in stack 
                //Debug.Log("AAAAAAAAAAAAAAAAAA:" + c);
                stack.Push(float.Parse(c, CultureInfo.InvariantCulture));
            }
            else
            {
                operators = c;
                //Debug.Log("Else C: " + c);
                //float val1 = stack.Pop();
                //Debug.Log("val1: " + val1);
                //float val2 = stack.Pop();
                //Debug.Log("val2: " + val2);

                //switch (c)
                //{
                //    case "+":
                //        stack.Push(val2 + val1);
                //        break;

                //    case "-":
                //        stack.Push(val2 - val1);
                //        break;

                //    case "/":
                //        stack.Push(val2 / val1);
                //        break;

                //    case "*":
                //        stack.Push(val2 * val1);
                //        break;
                //}
            }
        }
        if(stack.Count == 1)
        {
            return stack.Pop();
        }

        Debug.Log("stack size:" + stack.Count);
        float val1 = stack.Pop();
        Debug.Log("val1: " + val1);
        float val2 = stack.Pop();
        Debug.Log("val2: " + val2);
        Debug.Log("operator: " + operators);
        switch (operators)
        {
            
            case "+":
                stack.Push(val2 + val1);
                break;

            case "-":
                stack.Push(val2 - val1);
                break;

            case "/":
                stack.Push(val2 / val1);
                break;

            case "*":
                stack.Push(val2 * val1);
                break;
        }

        return stack.Pop();
    }

}
