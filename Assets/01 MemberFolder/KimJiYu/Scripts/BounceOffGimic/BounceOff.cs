using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
    [SerializeField] private float _bouncePower;

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector3 direction = collision.contacts[0].point - transform.position;
                direction.y = 0;
                direction = direction.normalized;

                Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (playerRigidbody == null)
                {
                    Debug.LogError("Player ������Ʈ�� Rigidbody�� �����ϴ�.");
                    return;
                }

                playerRigidbody.AddForce(direction * _bouncePower, ForceMode.Impulse);
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError($"BounceOff ��ũ��Ʈ���� ���� �߻�: {ex.Message} {ex.StackTrace}");
        }
    }
}