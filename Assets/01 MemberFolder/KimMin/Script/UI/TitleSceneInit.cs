using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleSceneInit : MonoBehaviour
{
    [SerializeField] private GameObject _element;
    private Sequence _seq;

    private void Awake()
    {
        DOTween.Init(this);
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title") // 특정 씬 이름 확인
        {
            MoveElement();
        }
    }

    private void MoveElement()
    {
        _seq?.Kill();

        _seq = DOTween.Sequence();
        _seq.Append(_element.transform.DOLocalMoveY(0, 2f).SetEase(Ease.OutBack));
    }
}
