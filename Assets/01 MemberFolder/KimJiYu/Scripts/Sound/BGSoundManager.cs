using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
