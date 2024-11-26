using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class BlindTrigger : MonoBehaviour
{
    [SerializeField] private Image[] _blindImage;
    private List<Image> _imgList;
    private int _rand = 0;

    private void Start()
    {
        _imgList = new List<Image>();
        _imgList.AddRange(_blindImage);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rand = Random.Range(0, _imgList.Count);

            _imgList[_rand].DOFade(1, 0.25f);
            StartCoroutine(DisableBlind(_imgList[_rand]));
        }
    }

    private IEnumerator DisableBlind(Image img)
    {
        yield return new WaitForSeconds(8f);

        img.DOFade(0, 0.25f);
    }
}
