using UnityEngine;
using TMPro;
using DG.Tweening;

public class StrokePopup : MonoBehaviour
{
    [SerializeField] private CheckGole _checkGole;

    private TextMeshProUGUI _popUpText;
    private Sequence _sequence;

    private void Awake()
    {
        _popUpText = GetComponentInChildren<TextMeshProUGUI>();
        _checkGole.OnGoleEvent += HandleOnGole;
        _popUpText.transform.localScale = Vector3.zero;
    }

    private void HandleOnGole(int stroke, GoleEnum gole)
    {
        Color col = _checkGole.strokeDic[gole];
        _sequence = DOTween.Sequence();

        _popUpText.color = col;
        _popUpText.faceColor = col;
        _popUpText.text = gole.ToString();
        _popUpText.ForceMeshUpdate();

        _sequence
            .Append(_popUpText.transform.DOScale(1.5f, 0.5f))
            .AppendInterval(0.5f)
            .Append(_popUpText.transform.DOScale(0, 0.5f)
            .SetEase(Ease.InOutBack));
    }
}
