using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndTransition : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;
    private HoleManager _holeManager;

    private void Awake()
    {
        _holeManager = GetComponent<HoleManager>();
        _holeManager.OnGameEndEvent += HandleGameEnd;
    }

    private void HandleGameEnd()
    {
        _transitionImage.DOFade(1, 2.0f).OnComplete(() => SceneManager.LoadScene("GameEnd"));
    }
}
