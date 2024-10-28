using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VikingRotate : MonoBehaviour
{
    [SerializeField] private float _interval = 0.3f;
    [SerializeField] private float _swingTime = 1;

    private Sequence _rotateSequence;

    private void Start()
    {
        _rotateSequence = DOTween.Sequence();
        Viking();
    }

    private void Viking()
    {
        _rotateSequence.Append(transform.DORotate(new Vector3(45, 0, 0), _swingTime)).SetEase(Ease.InSine);
        _rotateSequence.AppendInterval(_interval);
        _rotateSequence.Append(transform.DORotate(new Vector3(-45, 0, 0), _swingTime)).SetEase(Ease.InSine);
        _rotateSequence.AppendInterval(_interval);
        _rotateSequence.SetLoops(-1, LoopType.Yoyo);
        _rotateSequence.Play();
    }
}
