using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class TitleButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _btn;

    private Vector3 _oldPosition;

    private void Awake()
    {
        _btn = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _btn.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f),0.1f).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _btn.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f).SetUpdate(true);
    }
}
