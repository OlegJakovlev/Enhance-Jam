using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretLogo : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    private void OnTriggerEnter(Collider collider)
    {
        logo.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        logo.SetActive(false);
    }
}
