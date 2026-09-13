using UnityEngine;
using System.Collections.Generic;

public class DifficultyManager : MonoBehaviour
{
    [System.Serializable]
    public class DifficultyLevel
    {
        public string levelName;  // Easy, Normal, Hard, Extreme
        public float aiTrafficMultiplier;
        public float vehicleDamageScale;
        public float fuelConsumptionRate;
        public float missionTimeMultiplier;
        public float missionRewardMultiplier;
        public float accidentProbability;
    }

    public DifficultyLevel currentDifficulty;
    private List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();

    private void InitializeDifficultyLevels()
    {
        difficultyLevels.Add(new DifficultyLevel
        {
            levelName = "Easy",
            aiTrafficMultiplier = 0.6f,
            vehicleDamageScale = 0.5f,
            fuelConsumptionRate = 0.7f,
            missionTimeMultiplier = 1.5f,
            missionRewardMultiplier = 0.8f,
            accidentProbability = 0.02f
        });

        difficultyLevels.Add(new DifficultyLevel
        {
            levelName = "Normal",
            aiTrafficMultiplier = 1.0f,
            vehicleDamageScale = 1.0f,
            fuelConsumptionRate = 1.0f,
            missionTimeMultiplier = 1.0f,
            missionRewardMultiplier = 1.0f,
            accidentProbability = 0.05f
        });

        difficultyLevels.Add(new DifficultyLevel
        {
            levelName = "Hard",
            aiTrafficMultiplier = 1.4f,
            vehicleDamageScale = 1.5f,
            fuelConsumptionRate = 1.3f,
            missionTimeMultiplier = 0.8f,
            missionRewardMultiplier = 1.5f,
            accidentProbability = 0.1f
        });

        difficultyLevels.Add(new DifficultyLevel
        {
            levelName = "Extreme",
            aiTrafficMultiplier = 1.8f,
            vehicleDamageScale = 2.0f,
            fuelConsumptionRate = 1.6f,
            missionTimeMultiplier = 0.6f,
            missionRewardMultiplier = 2.5f,
            accidentProbability = 0.15f
        });
    }

    public void SetDifficulty(string difficultyName)
    {
        var difficulty = difficultyLevels.Find(d => d.levelName == difficultyName);
        if (difficulty != null)
        {
            currentDifficulty = difficulty;
            ApplyDifficultySettings();
            Debug.Log($"Difficulty set to: {difficultyName}");
        }
        else
        {
            Debug.LogError($"Difficulty not found: {difficultyName}");
        }
    }

    private void ApplyDifficultySettings()
    {
        // Apply to game systems
        Time.timeScale = 1.0f / currentDifficulty.missionTimeMultiplier;
        Debug.Log($"Applied: Traffic={currentDifficulty.aiTrafficMultiplier}x, Damage={currentDifficulty.vehicleDamageScale}x, Reward={currentDifficulty.missionRewardMultiplier}x");
    }
}
