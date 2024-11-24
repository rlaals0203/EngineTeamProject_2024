using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BlindTrigger : MonoBehaviour
{
    [SerializeField] private Image[] _blindImage;
    private int _rand = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _rand = Random.Range(0, _blindImage.Length);

            _blindImage[_rand].DOFade(1, 0.25f);

            StartCoroutine(DisableBlind());
        }
    }

    private IEnumerator DisableBlind()
    {
        yield return new WaitForSeconds(2.5f);

        _blindImage[_rand].DOFade(0, 0.25f);
    }
}
