using UnityEngine;
using TMPro;
using DG.Tweening;

public class StrokePopup : MonoBehaviour
{
    private TextMeshProUGUI _popUpText;
    [SerializeField] private CheckGole _checkGole;

    private void Awake()
    {
        _popUpText = GetComponentInChildren<TextMeshProUGUI>();
        _checkGole.OnGoleEvent += HandleOnGole;
        _popUpText.transform.localScale = Vector3.zero;
    }

    private void HandleOnGole(int stroke, string strokeName)
    {
        _popUpText.text = strokeName;
        _popUpText.transform.DOScale(2, 0.5f).SetEase(Ease.InOutBack);
    }
}
