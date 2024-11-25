using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    private StageManager _stageManager;
    private GameObject _element;
    private Sequence seq;
    private Sequence seq2;

    [SerializeField] private Image _background;

    [SerializeField] private TextMeshProUGUI _titleTxt;
    [SerializeField] private TextMeshProUGUI _strokeTxt;
    [SerializeField] private TextMeshProUGUI _timeTxt;
    [SerializeField] private TextMeshProUGUI _hioTxt;
    [SerializeField] private TextMeshProUGUI _condorTxt;
    [SerializeField] private TextMeshProUGUI _albTxt;
    [SerializeField] private TextMeshProUGUI _eagleTxt;
    [SerializeField] private TextMeshProUGUI _birdieTxt;
    [SerializeField] private TextMeshProUGUI _parTxt;


    private void Awake()
    {
        _element = _background.transform.Find("Elements").gameObject;
        _stageManager = GameObject.Find("StageManager")
            .GetComponent<StageManager>();
    }

    private void Start()
    {
        TextTween();
    }

    private void TextTween()
    {
        seq = DOTween.Sequence();

        _strokeTxt.text = $"타수\n{_stageManager.totalStroke}";
        _timeTxt.text = $"플레이 시간\n{Mathf.RoundToInt(_stageManager.totalTime)}";

        _hioTxt.text = _stageManager.strokeNameDic[GoleEnum.HOLE_IN_ONE].ToString();
        _condorTxt.text = _stageManager.strokeNameDic[GoleEnum.CONDOR].ToString();
        _albTxt.text = _stageManager.strokeNameDic[GoleEnum.ALBATROSS].ToString();
        _eagleTxt.text = _stageManager.strokeNameDic[GoleEnum.EAGLE].ToString();
        _birdieTxt.text = _stageManager.strokeNameDic[GoleEnum.BIRDIE].ToString();
        _parTxt.text = _stageManager.strokeNameDic[GoleEnum.PAR].ToString();


        seq.Append(_titleTxt.transform.parent.DOMoveY(100, 2f)
            .SetEase(Ease.InOutBack))
            .Append(_strokeTxt.transform.parent.DOMoveY(500, 2f)
            .SetEase(Ease.InOutBack))
            .Append(_timeTxt.transform.parent.DOMoveY(500, 2f)
            .SetEase(Ease.InOutBack))
            .Append(_hioTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .Append(_condorTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .Append(_albTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .Append(_eagleTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .Append(_birdieTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .Append(_parTxt.transform.parent.DOMoveY(200, 1.5f)
            .SetEase(Ease.InOutBack))
            .OnComplete(() =>
            {
                TransitionTween();
            });


    }

    private void TransitionTween()
    {
        seq2 = DOTween.Sequence();
        seq.Kill();

        seq2.Append(_element.transform.DOMoveY(3000, 1.5f))
            .SetEase(Ease.InOutBack)
            .Append(_background.DOColor(Color.white, 1f))
            .OnComplete(() =>
            {
                Debug.Log("아아");
                SceneManager.LoadScene("Title");
            });
    }
}
