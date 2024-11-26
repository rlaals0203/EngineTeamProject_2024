using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleSceneInit : MonoBehaviour
{
    [SerializeField] private GameObject _element;
    private Sequence _seq;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        _seq = DOTween.Sequence();
        _seq.Append(_element.transform.DOLocalMoveY(0, 2f).SetEase(Ease.InOutBack));
    }
}
