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
        transform.DORotate(new Vector3(45, 0, 0), _swingTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
