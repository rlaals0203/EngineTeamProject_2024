using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject _bgPanel;
    [SerializeField] private GameObject _dontClick;

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
        _dontClick.SetActive(false);
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
        _dontClick.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOLocalMoveY(0, 1));
        sequence.AppendCallback(() => _isMove = true);
        //sequence.AppendCallback(() => Time.timeScale = 0);
    }

    private void UpPanel()
    {
        //Time.timeScale = 1;
        _dontClick.SetActive(false);
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
        SceneManager.LoadScene("Title");
    }
}
