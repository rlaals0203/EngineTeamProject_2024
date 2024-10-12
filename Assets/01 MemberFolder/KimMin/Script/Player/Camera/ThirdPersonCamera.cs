using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Setting")]
    public Transform oriantation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rigid;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3
            (transform.position.x, player.position.y, transform.position.z);

        oriantation.forward = viewDir.normalized;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 inputDir = oriantation.forward * yInput + oriantation.right * xInput;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir, rotationSpeed * Time.deltaTime);
        }
    }
}
