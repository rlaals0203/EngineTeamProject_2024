using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSoundManager : MonoBehaviour
{
    public static BGSoundManager instance;
    [SerializeField] private Slider _bgmVolumeSlider;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (_bgmVolumeSlider == null)
        {
            _bgmVolumeSlider = GameObject.Find("BgmSlider").GetComponent<Slider>();
            if (_bgmVolumeSlider != null)
            {
                _bgmVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
                _bgmVolumeSlider.onValueChanged.AddListener(delegate { BgmChangeVolume(); });
            }
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("bgmVolume"))
        {
            _bgmVolumeSlider.value = 1f;
            BgmLoad();
        }

        else
            BgmLoad();
    }

    public void BgmChangeVolume()
    {
        _audioSource.volume = _bgmVolumeSlider.value;
        BgmSave();
    }

    private void BgmLoad()
    {
        _bgmVolumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    }

    private void BgmSave()
    {
        PlayerPrefs.SetFloat("bgmVolume",_bgmVolumeSlider.value);
    }
}
