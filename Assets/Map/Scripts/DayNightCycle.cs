using UnityEngine;
using System.Collections.Generic;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sunLight;
    [SerializeField] private float cycleSpeed = 1.0f;  // In-game minutes per real second
    
    private float timeOfDay = 6.0f;  // Start at 6 AM
    private float dayLength = 1440.0f;  // 24 hours in minutes
    private bool isNight = false;

    [System.Serializable]
    public class TimeEvent
    {
        public float hour;
        public string eventName;
        public System.Action eventAction;
    }

    private List<TimeEvent> timeEvents = new List<TimeEvent>();

    private void Start()
    {
        InitializeTimeEvents();
    }

    private void InitializeTimeEvents()
    {
        timeEvents.Add(new TimeEvent { hour = 6, eventName = "Sunrise" });
        timeEvents.Add(new TimeEvent { hour = 18.5f, eventName = "Sunset" });
        timeEvents.Add(new TimeEvent { hour = 20, eventName = "Headlights Required" });
        timeEvents.Add(new TimeEvent { hour = 22, eventName = "Night Mode" });
    }

    private void Update()
    {
        // Advance time
        timeOfDay += Time.deltaTime * (cycleSpeed / 60.0f);  // Convert to hours
        
        // Wrap around 24 hours
        if (timeOfDay >= 24.0f)
        {
            timeOfDay -= 24.0f;
        }

        UpdateSunlight();
        CheckTimeEvents();
    }

    private void UpdateSunlight()
    {
        // Calculate sun rotation based on time of day
        // 6 AM = sunrise, 18 PM = sunset
        float sunAngle = (timeOfDay - 6.0f) * 15.0f;  // 360 degrees / 24 hours
        sunLight.transform.rotation = Quaternion.AngleAxis(sunAngle, Vector3.right);

        // Adjust light intensity based on time
        if (timeOfDay >= 6 && timeOfDay < 18.5f)
        {
            // Day time
            sunLight.intensity = Mathf.Clamp01(1.0f);
            isNight = false;
        }
        else if (timeOfDay >= 20 || timeOfDay < 5)
        {
            // Night time
            sunLight.intensity = Mathf.Clamp01(0.3f);
            isNight = true;
        }
        else
        {
            // Twilight
            float twilightFactor = (timeOfDay - 18.5f) / 1.5f;
            sunLight.intensity = Mathf.Lerp(1.0f, 0.3f, twilightFactor);
        }
    }

    private void CheckTimeEvents()
    {
        foreach (var timeEvent in timeEvents)
        {
            // Trigger events at specific times
            if (Mathf.Abs(timeOfDay - timeEvent.hour) < 0.1f)
            {
                Debug.Log($"Time Event: {timeEvent.eventName} at {timeEvent.hour:F1}:00");
                timeEvent.eventAction?.Invoke();
            }
        }
    }

    public float GetTimeOfDay()
    {
        return timeOfDay;
    }

    public string GetTimeFormatted()
    {
        int hours = (int)timeOfDay;
        int minutes = (int)((timeOfDay - hours) * 60);
        return $"{hours:D2}:{minutes:D2}";
    }

    public bool IsNightTime()
    {
        return isNight;
    }
}
