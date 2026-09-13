using UnityEngine;
using System.Collections.Generic;

public class PoliceSystem : MonoBehaviour
{
    [System.Serializable]
    public class Checkpoint
    {
        public int id;
        public string name;
        public string section;
        public float positionKm;
        public string checkpointType;  // speed_enforcement, toll, inspection, weigh_station
        public int speedLimitKmh;
        public int fineAmount;
        public bool isActive;
    }

    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private Dictionary<string, int> speedLimits = new Dictionary<string, int>();
    private Dictionary<string, int> penalties = new Dictionary<string, int>();

    private void InitializeCheckpoints()
    {
        checkpoints.Add(new Checkpoint
        {
            id = 1,
            name = "Misungwi Checkpoint",
            section = "S02",
            positionKm = 8.5f,
            checkpointType = "speed_enforcement",
            speedLimitKmh = 60,
            fineAmount = 50000,
            isActive = true
        });

        checkpoints.Add(new Checkpoint
        {
            id = 3,
            name = "Singida Toll Gate",
            section = "S07",
            positionKm = 53.2f,
            checkpointType = "toll",
            speedLimitKmh = 0,
            fineAmount = 3500,
            isActive = true
        });

        // Add more checkpoints...
    }

    private void InitializeSpeedLimits()
    {
        speedLimits["residential"] = 40;
        speedLimits["town_center"] = 50;
        speedLimits["highway"] = 100;
        speedLimits["school_zone"] = 40;
        speedLimits["sharp_curve"] = 50;
        speedLimits["mountain_descent"] = 60;
    }

    private void InitializePenalties()
    {
        penalties["speeding_1_20"] = 25000;
        penalties["speeding_21_40"] = 50000;
        penalties["speeding_40plus"] = 100000;
        penalties["no_license"] = 100000;
        penalties["no_documents"] = 75000;
        penalties["hit_and_run"] = 500000;
        penalties["reckless_driving"] = 150000;
    }

    public int CalculateSpeedingFine(int speedLimit, int playerSpeed)
    {
        int speedOver = playerSpeed - speedLimit;
        if (speedOver <= 0) return 0;
        
        if (speedOver <= 20) return penalties["speeding_1_20"];
        if (speedOver <= 40) return penalties["speeding_21_40"];
        return penalties["speeding_40plus"];
    }

    public void CheckPlayerAtCheckpoint(int checkpointId, int playerSpeed)
    {
        var checkpoint = checkpoints.Find(c => c.id == checkpointId);
        if (checkpoint != null && checkpoint.isActive)
        {
            if (checkpoint.checkpointType == "speed_enforcement")
            {
                int fine = CalculateSpeedingFine(checkpoint.speedLimitKmh, playerSpeed);
                if (fine > 0)
                {
                    Debug.LogWarning($"Speed violation at {checkpoint.name}! Fine: {fine} TZS");
                }
            }
        }
    }
}
