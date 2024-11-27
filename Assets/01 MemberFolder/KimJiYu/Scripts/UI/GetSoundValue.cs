using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSoundValue : MonoBehaviour
{
    [SerializeField] private bool _bgm; // true: BGM, false: SFX

    private Slider _slider;
    private AudioSource _audioSound;
    private string _prefKey;
    private string _managerName;

    private void Awake()
    {
        _managerName = _bgm ? "BGSoundManager" : "SFXSoundManager";
        _prefKey = _bgm ? "bgmVolume" : "sfxVolume";

        GameObject manager = GameObject.Find(_managerName);
        _audioSound = manager.GetComponent<AudioSource>();

        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(_prefKey);
        _audioSound.volume = savedVolume;
        _slider.value = savedVolume;
    }

    public void ChangeValue()
    {
        _audioSound.volume = _slider.value;
        PlayerPrefs.SetFloat(_prefKey, _slider.value);
    }
}