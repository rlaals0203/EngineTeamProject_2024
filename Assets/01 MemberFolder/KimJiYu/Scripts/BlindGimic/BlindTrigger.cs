using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _blindImage;

    private void Awake()
    {

    }

    private void Start()
    {
        _blindImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _blindImage.SetActive(true);
            StartCoroutine(DisableBlind());
        }
    }

    private IEnumerator DisableBlind()
    {
        yield return new WaitForSeconds(2f);
        _blindImage.SetActive(false);
    }
}
