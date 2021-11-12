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
        float tmp = levelTimer.GetTimeLeft();
        string result = tmp.ToString();
        
        try
        {
            textValue.text = defaultText + result.Substring(0, result.Length > 4 ? ((tmp > 100) ? 6 : 4) : result.Length) + " sec";
        }
        catch (ArgumentOutOfRangeException e)
        {
            textValue.text = defaultText + result.Substring(0, result.Length) + " sec";
        }
    }
}
