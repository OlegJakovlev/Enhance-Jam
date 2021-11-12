using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerText : MonoBehaviour
{
    private readonly string defaultText = "Time Left: ";
    [SerializeField] private Text textValue;

    [SerializeField] LevelTimer levelTimer;

    private void Awake()
    {
        textValue = GetComponent<Text>();
    }


    private void Update()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        try
        {
            string tmp = levelTimer.GetTimeLeft().ToString();
            textValue.text = defaultText + tmp.Substring(0, (tmp.Length > 4) ? 4 : tmp.Length) + " sec";
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NOO");
        }
    }
}
