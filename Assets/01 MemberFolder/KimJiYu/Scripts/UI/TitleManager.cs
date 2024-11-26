using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject _element;
    private Sequence seq;

    void Start()
    {
        seq = DOTween.Sequence();

        seq.Append(_element.transform.DOMoveY(3000, 1.5f))
            .SetEase(Ease.InOutBack);
    }
}
