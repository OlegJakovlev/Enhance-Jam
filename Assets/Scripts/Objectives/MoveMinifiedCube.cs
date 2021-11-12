using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveMinifiedCube : MonoBehaviour
{
    private float _speed = 0.25f;

    private Rigidbody _rigidbody;
    [SerializeField] Vector3 _startingPoint;
    [SerializeField] Vector3 _finishPoint;

    private void Update()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + (_finishPoint * Time.fixedDeltaTime * _speed));    
    }
}
