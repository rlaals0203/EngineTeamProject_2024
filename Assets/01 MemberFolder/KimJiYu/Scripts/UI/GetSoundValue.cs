using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSoundValue : MonoBehaviour
{
    [SerializeField] private bool _bgm;

    private Slider _slider;
    private GameObject _value;
    private AudioSource _audioSound;

    private void Awake()
    {
        if (_bgm)
        {
            _value = GameObject.Find("BGSoundManager");
            if (_value != null)
                Debug.Log("BG사운드 찾음");
            _audioSound = _value.GetComponent<AudioSource>();
        }

        else if (!_bgm)
        {
            _value = GameObject.Find("SFXSoundManager");
            if (_value != null)
                Debug.Log("SFX사운드 찾음");
            _audioSound = _value.GetComponent<AudioSource>();
        }
            _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if(_value != null)
            _slider.value = _audioSound.volume;
    }


}
