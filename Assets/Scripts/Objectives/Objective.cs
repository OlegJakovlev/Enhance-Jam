using System;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] protected int _points = 5;

    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.IncrementScore(_points);

            if (collider.TryGetComponent(out Movement controller))
            {
                controller.DecreaseSpeed(_points);
            }

            Destroy(gameObject);
        }
    }
}