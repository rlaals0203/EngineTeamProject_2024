using System;
using UnityEngine;
using UnityEngine.UI;

public class SFXSoundManager : MonoBehaviour
{
    public static SFXSoundManager instance;
    public Action OnHoleInOneClip;
    public Action OnAlbatrosClip;
    public Action OnGoleClip;
    public Action OnShotClip;

    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private AudioClip _holeInOneClip;
    [SerializeField] private AudioClip _albatrosClip;
    [SerializeField] private AudioClip _goleClip;
    [SerializeField] private AudioClip _shotClip;

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

        OnHoleInOneClip += HoleInOneSound;
        OnAlbatrosClip += AlbatrosSound;
        OnGoleClip += GoleSound;
        OnShotClip += ShotSound;
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

    public void ChangeSfxClip()
    {
        _audioSource.volume = _sfxVolumeSlider.value;
    }

    public void HoleInOneSound()
    {
        _audioSource.PlayOneShot(_holeInOneClip);
    }

    public void AlbatrosSound()
    {
        _audioSource.PlayOneShot(_albatrosClip);
    }

    public void GoleSound()
    {
        _audioSource.PlayOneShot(_goleClip);
    }

    public void ShotSound()
    {
        _audioSource.PlayOneShot(_shotClip);
    }
}
 