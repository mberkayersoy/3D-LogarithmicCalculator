using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
public abstract class ButtonBase : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    public bool isNumeric;
    public string value;
    public InputManager inputManager;
    public abstract void Operation(List<string> text);
    public abstract void DisplayText(List<string> text);

    private void Awake()
    {
        startPos = transform.position;
        endPos = startPos - new Vector3(0, 0, 0.08f);
    }
    private void Start()
    {
        DOTween.Init();
    }
    public virtual void Move()
    {
        transform.DOLocalMove(endPos, 0.15f).SetEase(Ease.OutCubic).OnComplete(() => 
        transform.DOLocalMove(startPos, 0.15f).SetEase(Ease.OutCubic));
    }
}
