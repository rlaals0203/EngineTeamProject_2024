using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleSceneInit : MonoBehaviour
{
    [SerializeField] private GameObject _element;

    private void Start()
    {
        _element.transform.DOLocalMoveY(0, 2f).SetEase(Ease.InOutBack);
    }
}
