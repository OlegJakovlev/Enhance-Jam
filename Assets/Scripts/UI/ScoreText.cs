using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private Player player;

    private readonly string defaultText = "Score: ";
    [SerializeField] private Text textValue;
    [SerializeField] private LevelTimer timer;

    private void Awake()
    {
        textValue = GetComponent<Text>();
    }

    private void Update()
    {
        if (timer.GetTimeLeft() > 0.05f)
            UpdateText();
    }

    public void UpdateText()
    {
        textValue.text = defaultText + player.GetScore().ToString();
    }
}
