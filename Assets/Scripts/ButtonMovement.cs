using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonMovement : MonoBehaviour
{   
    private Vector3 startPos;
    private Vector3 endPos;

    private void Awake()
    {
        startPos = transform.position;
        endPos = startPos - new Vector3(0, 0.08f, 0);
    }
    private void Start()
    {
        DOTween.Init();
    }
    public void Move()
    {
        transform.DOLocalMove(endPos, 0.15f).SetEase(Ease.OutCubic).OnComplete(() => ComeBack());
    }
    void ComeBack()
    {
        transform.DOLocalMove(startPos, 0.15f).SetEase(Ease.OutCubic);
    }
}
