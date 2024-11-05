using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            _volumeSlider.value = 1f;
            Load();
        }

        else
            Load();
    }

    public void ChangeVolume()
    {
        _audioSource.volume = _volumeSlider.value;
        Save();
    }

    private void Load()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",_volumeSlider.value);
    }
}
