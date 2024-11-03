using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class UIExpand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _targetImage;
    private Sequence _sequence;
    private Vector2 _startScale;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
        _startScale = _targetImage.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _targetImage.transform.localScale = new Vector2(0f, 0.1f);

        _sequence
            .Append(_targetImage.transform.DOScaleX(1f, 0.5f)
            .SetEase(Ease.OutBack))
            .Append(_targetImage.transform.DOScaleY(1f, 0.5f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sequence
            .Append(_targetImage.transform.DOScaleY(0f, 1f)
            .SetEase(Ease.OutBack))
            .Append(_targetImage.transform.DOScaleX(0f, 0.5f));
    }
}
