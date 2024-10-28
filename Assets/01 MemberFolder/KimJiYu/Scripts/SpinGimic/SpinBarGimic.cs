using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBarGimic : MonoBehaviour
{
    [SerializeField] private float _bouncePower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * _bouncePower, ForceMode.Impulse);
        }
    }
}
