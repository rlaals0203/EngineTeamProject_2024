using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScreen : MonoBehaviour
{
    [Header("ȭ�� �ʺ�")]
    [SerializeField] private static int _screenWidth = 1920; public static int ScreenWidth { get => _screenWidth; set => _screenWidth = value; }
    [Header("ȭ�� ����")]
    [SerializeField] private static int _screenHeight = 1080; public static int ScreenHeight { get => _screenHeight; set => _screenHeight = value; }
    [Header("FullScreen")]
    [SerializeField] private static bool _fullScreen = true; public static bool FullScrren { get => _fullScreen; set => _fullScreen = value; }


    private void Awake()
    {

        fixedScreenSet(1920, 1080, true);
    }


    public static void FixedScreenSet() => fixedScreenSet(_screenWidth, _screenHeight, _fullScreen);
    public static void FixedScreenSet(int Width, int Height) => fixedScreenSet(Width, Height, _fullScreen);
    public static void FixedScreenSet(int Width, int Height, bool fullScreen) => fixedScreenSet(Width, Height, fullScreen);

    private static void fixedScreenSet(int Width, int Height, bool fullScreen)
    {
        Screen.SetResolution(Width, Height, fullScreen);
    }
}