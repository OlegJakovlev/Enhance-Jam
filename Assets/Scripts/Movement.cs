using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _speedMultiplier = 2f;

    private Vector3 forward, right;

    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed *= _speedMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed /= _speedMultiplier;
        }
        
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * _moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * _moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;

        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
