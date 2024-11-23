using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject _bgPanel;

    private Image _settingPanel;

    private bool _isMove = false;
    private float _oldPosition;

    private Sequence sequence;

    private void Awake()
    {
        _settingPanel = _bgPanel.GetComponent<Image>();
    }

    private void Start()
    {
        _bgPanel.SetActive(false);
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
        _bgPanel.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOLocalMoveY(0, 1));
        sequence.AppendCallback(() => _isMove = true);
    }

    private void UpPanel()
    {
        _bgPanel.SetActive(false);
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOMoveY(_oldPosition, 1));
        sequence.AppendCallback(() => _isMove = false);
    }

    public void PanelUpButton()
    {
        if (_isMove)
            UpPanel();
    }

    public void PanelDownButton()
    {
        if(!_isMove)
            DownPanel();
    }

    public void returnTitle()
    {
        SceneManager.LoadScene("TestTitle");
    }
}
