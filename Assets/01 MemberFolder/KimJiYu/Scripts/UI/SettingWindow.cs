using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    private Image _settingPanel;

    private bool _isMove = false;
    private float _oldPosition;

    private Sequence sequence;

    private void Awake()
    {
        _settingPanel = GetComponent<Image>();
    }

    private void Start()
    {
        DOTween.Init();
        _oldPosition = _settingPanel.rectTransform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isMove)
            {
                DownPanel();
            }
            else if (_isMove)
            {
                UpPanel();
            }
        }
    }

    private void DownPanel()
    {
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOLocalMoveY(0, 1));
        sequence.AppendCallback(() => _isMove = true);
    }

    private void UpPanel()
    {
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOMoveY(_oldPosition, 1));
        sequence.AppendCallback(() => _isMove = false);
    }
}
