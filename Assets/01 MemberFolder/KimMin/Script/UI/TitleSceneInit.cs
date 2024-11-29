using UnityEngine;
using DG.Tweening;

public class TitleSceneInit : MonoBehaviour
{
    [SerializeField] private GameObject _element;
    private Sequence _seq;

    private void Awake()
    {
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        MoveElement();
    }

    private void MoveElement()
    {
        SettingWindow.Instance._isMoving = true;

        _seq = DOTween.Sequence();
        _seq.Append(_element.transform.DOLocalMoveY(0, 2f).SetEase(Ease.OutBack));
        _seq.OnComplete(() => SettingWindow.Instance._isMoving = false);
    }
}
