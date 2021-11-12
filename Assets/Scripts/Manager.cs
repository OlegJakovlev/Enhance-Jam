using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Movement playerController;
    [SerializeField] private LevelTimer timer;

    [SerializeField] private GameObject initial_canvas;
    [SerializeField] private GameObject hidden_canvas;

    private void Update()
    {
        if (timer.GetTimeLeft() <= 0.1f && !hidden_canvas.activeInHierarchy)
        {
            playerController.enabled = false;
            initial_canvas.SetActive(false);
            hidden_canvas.SetActive(true);
        }
    }
}
