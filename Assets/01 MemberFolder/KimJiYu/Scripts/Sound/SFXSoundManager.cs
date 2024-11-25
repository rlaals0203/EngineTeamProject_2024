using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SFXSoundManager : MonoBehaviour
{
    public static SFXSoundManager instance;
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private AudioClip _audioClip;

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
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            _sfxVolumeSlider.value = 1f;
            SfxLoad();
        }

        else
            SfxLoad();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySfxClip();
        }
    }

    public void SfxChangeVolume()
    {
        _audioSource.volume = _sfxVolumeSlider.value;
        SfxSave();
    }

    private void SfxLoad()
    {
        _sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void SfxSave()
    {
        PlayerPrefs.SetFloat("sfxVolume",_sfxVolumeSlider.value);
    }

    public void PlaySfxClip()
    {
        if (_audioClip == null)
            return;

        _audioSource.volume = _sfxVolumeSlider.value;
        _audioSource.PlayOneShot(_audioClip);
    }
}
 