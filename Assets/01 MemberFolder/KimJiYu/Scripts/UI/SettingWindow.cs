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
    private BallShooting _ballShooting;

    private bool _isMove = false;
    private bool _isMoving = false;
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
        //else
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
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

        Debug.Log(Time.timeScale);
        if (_playerSetting != null)
        {
            if (!_isMoving)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!_isMove && !_playerSetting.IsRelease)
                    {
                        PanelDownButton();
                    }
                    else if (_isMove)
                    {
                        PanelUpButton();
                    }
                }
            }
        }

        if (!_isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_isMove)
                {
                    PanelDownButton();
                }
                else if (_isMove)
                {
                    PanelUpButton();
                }
            }
        }
        
    }

    private void DownPanel()
    {
        _isMoving = true;

        if (_camera != null)
        {
            _freeLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (_playerSetting != null)
        {
            if (_ballShooting == null)
                _ballShooting = _playerSetting.GetComponent<BallShooting>();

            _playerSetting.CanShot = false;
            _ballShooting.CancelShooting();
        }
        _dontClick.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOLocalMoveY(0, 1.2f));
        sequence.AppendCallback(() => Time.timeScale = 0);
        sequence.AppendCallback(() => _isMove = true);
        sequence.OnComplete(() => _isMoving = false);
    }

    private void UpPanel()
    {
        _isMoving = true;
        if (_playerSetting != null)
        {
            _playerSetting.CanShot = false;
        }
        Time.timeScale = 1;
        sequence = DOTween.Sequence();
        sequence.Append(_settingPanel.rectTransform.DOMoveY(_oldPosition, 1));
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
        sequence.AppendCallback(()=> _isMove = false);;
        sequence.OnComplete(()=> _isMoving = false);;
    }

    public void PanelUpButton()
    {
        if (!_isMoving)
        {
            if (_isMove)
                UpPanel();

        }
    }

    public void PanelDownButton()
    {
        if (!_isMoving)
        {
            if (!_isMove)
                DownPanel();
        }
        
    }

    public void returnTitle()
    {
        if (!_isMoving)
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(0);
        }
            
       
    }
}
