using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public bool TimeIsUp = false;
    
    private bool _welcomeTimerAvailable;
    private bool _levelTimerAvailable;
    
    [SerializeField] private float _levelTimer = 3f;
    [SerializeField] private float _timeLeft = 100f ;

    void Update()
    {
        if (_welcomeTimerAvailable && _levelTimer > 0)
        {
            _levelTimer -= Time.deltaTime;

            if (_levelTimer <= 0)
            {
                Invoke(nameof(DisableWelcomeTimer), 0.5f);
                Invoke(nameof(SetLevelTimerActive), 0.5f);
            }
        }

        if (_levelTimerAvailable && _timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft <= 0)
            {
                TimeIsUp = true;
            }
        }
    }

    private void DisableWelcomeTimer()
    {
        _welcomeTimerAvailable = false;
    }

    private void DisableLevelTimer()
    {
        _levelTimerAvailable = false;
    }
    private void SetLevelTimerActive()
    {
        _levelTimerAvailable = true;
    }
}
