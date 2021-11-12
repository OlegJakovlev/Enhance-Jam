using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public bool TimeIsUp = false;
    private bool _levelTimerAvailable = true;
    
    [SerializeField] private float _timeLeft = 100f;

    private void Update()
    {
        if (_levelTimerAvailable && _timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft <= 0)
            {
                TimeIsUp = true;
            }
        }
    }

    public float GetTimeLeft()
    {
        return _timeLeft;
    }
}
