using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordButton : OperationButtonBase
{
    public bool isRecording = false;
    Light recordLight;
    public DataButton data;
    void Start()
    {
        recordLight = GetComponent<Light>();
    }
    public override void Operation(List<string> text)
    {
        isRecording = !isRecording;
        recordLight.enabled = isRecording;
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
