using UnityEngine;
using TMPro;
using DG.Tweening;

public class StrokePopup : MonoBehaviour
{
    private TextMeshProUGUI _popUpText;
    [SerializeField] private CheckGole _checkGole;

    private Sequence _sequence;

    private void Awake()
    {
        _popUpText = GetComponentInChildren<TextMeshProUGUI>();
        _checkGole.OnGoleEvent += HandleOnGole;
        _popUpText.transform.localScale = Vector3.zero;
    }

    private void HandleOnGole(int stroke, string strokeName)
    {
        _sequence = DOTween.Sequence();
        _popUpText.text = strokeName;

        _sequence.Append(_popUpText.transform.DOScale(1.5f, 0.5f))
            .AppendInterval(0.5f)
            .Append(_popUpText.transform.DOScale(0, 0.5f).SetEase(Ease.InOutBack));
    }
}
