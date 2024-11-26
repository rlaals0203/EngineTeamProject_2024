using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    private CinemachineFreeLook _freeLook;

    [SerializeField] private float _stregth, _max, _min;

    private void Start()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GetMiddleDelta();
    }

    private void GetMiddleDelta()
    {
        float delta = Mouse.current.scroll.value.y;

        if (delta != 0)
            AdjustCameraZoom(delta / 100);
    }

    private void AdjustCameraZoom(float scrollInput)
    {
        for (int i = 0; i < _freeLook.m_Orbits.Length; i++)
        {
            // 각 Orbit의 반지름을 마우스 휠 입력에 따라 조정
            _freeLook.m_Orbits[i].m_Radius = Mathf.Clamp(
                _freeLook.m_Orbits[i].m_Radius - scrollInput * _stregth, _min, _max);
        }
    }
}
