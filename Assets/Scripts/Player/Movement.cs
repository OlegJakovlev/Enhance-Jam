using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f;
    [SerializeField] private float _speedMultiplier = 2f;

    private Rigidbody _rigidbody;
    private Vector3 _forward, _right;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = Vector3.Normalize(_forward);

        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;
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
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;

        Vector3 _rightMovement = _right * _moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = _forward * _moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(_rightMovement + upMovement);
        
        if (heading != Vector3.zero)
            transform.forward = heading;

        _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed * Time.deltaTime);

        //transform.position += _rightMovement;
        //;
    }

    public void DecreaseSpeed(float points)
    {
        switch (points)
        {
            case (5):
                _moveSpeed *= 0.90f;
                break;

            case (15):
                _moveSpeed *= 0.70f;
                break;

            case (35):
                _moveSpeed *= 0.60f;
                break;

            default:
                break;
        }
    }

    public void IncreaseSpeed(float points)
    {
        switch (points)
        {
            case (5):
                _moveSpeed *= 1.20f;
                break;

            case (15):
                _moveSpeed *= 1.40f;
                break;

            case (35):
                _moveSpeed *= 1.60f;
                break;

            default:
                break;
        }
    }
}
