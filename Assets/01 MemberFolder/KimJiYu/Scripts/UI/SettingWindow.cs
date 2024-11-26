using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject _bgPanel;
    [SerializeField] private GameObject _dontClick;

    private Image _settingPanel;
    private GameObject _camera;
    private GameObject _player;
    private CinemachineFreeLook _freeLook;
    private Player _playerSetting;

    private bool _isMove = false;
    private float _oldPosition;

    private Sequence sequence;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        if( _player != null )
            _playerSetting = _player.GetComponent<Player>();

        _camera = GameObject.Find("BallCamera");
        if (_camera != null)
            _freeLook = _camera.GetComponent<CinemachineFreeLook>();
        else
            Debug.Log("�ó׸ӽ� ã�� ����");
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
        if (_camera != null)
        {
            _freeLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (_playerSetting != null)
        {
            _playerSetting.CanShot = false;
            _playerSetting.IsRelease = false;
        }
        _dontClick.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOLocalMoveY(0, 1));
        sequence.AppendCallback(() => _isMove = true);
        sequence.AppendCallback(() => Time.timeScale = 0);
    }

    private void UpPanel()
    {
        if (_playerSetting != null)
        {
            _playerSetting.CanShot = false;
        }
        Time.timeScale = 1;
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOMoveY(_oldPosition, 1));
        sequence.AppendCallback(() => _isMove = false);
        sequence.AppendCallback(() => _dontClick.SetActive(false));
        sequence.AppendCallback(() => 
        { 
            if (_camera != null)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _freeLook.enabled = true;
            }
        });
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
