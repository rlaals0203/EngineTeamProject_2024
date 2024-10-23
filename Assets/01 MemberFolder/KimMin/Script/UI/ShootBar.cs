using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private GameObject _background;
    private GameObject _fill;

    private BallShooting _ballShooting;
    private CinemachineFreeLook _freeLook;

    private bool _isActive;

    public void Awake()
    {
        _ballShooting = _player.GetComponent<BallShooting>();
        _freeLook = GameObject.Find("BallCamera").GetComponent<CinemachineFreeLook>();

        _background = transform.Find("Background").gameObject;
        _fill = _background.transform.Find("Fill").gameObject;
    }

    private void Update()
    {
        if (_player.IsRelease)
        {
            ChangeSlider();
            ActiveObjects(true);
        }
        else
            ActiveObjects(false);
    }

    private void ChangeSlider()
    {
        _fill.transform.localScale = new Vector3
            (_ballShooting.shootPower / 100,_fill.transform.localScale.y);
    }

    private void ActiveObjects(bool active)
    {
        if (_isActive == active)
            return;

        _isActive = active;

        _background.SetActive(active);
        _freeLook.enabled = !active;
    }
}
