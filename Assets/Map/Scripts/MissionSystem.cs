using UnityEngine;
using System.Collections.Generic;

public class MissionSystem : MonoBehaviour
{
    [System.Serializable]
    public class Mission
    {
        public string missionId;
        public string missionName;
        public string routeType;
        public int distanceKm;
        public int timeLimit;
        public int rewardBase;
        public int rewardPerKm;
        public int penaltyLatePerMinute;
        public bool completed;
        public int earnedReward;
    }

    private List<Mission> activeMissions = new List<Mission>();
    private List<Mission> completedMissions = new List<Mission>();

    public void CreateMission(string missionType, int distanceKm)
    {
        Mission mission = new Mission();
        
        switch (missionType)
        {
            case "delivery":
                mission.missionName = "Standard Cargo Delivery";
                mission.rewardBase = 5000;
                mission.rewardPerKm = 500;
                mission.timeLimit = distanceKm / 80 * 60;  // minutes
                break;
            
            case "passenger":
                mission.missionName = "Passenger Express Service";
                mission.rewardBase = 8000;
                mission.rewardPerKm = 200;
                mission.timeLimit = distanceKm / 75 * 60;
                mission.penaltyLatePerMinute = 200;
                break;
            
            case "freight":
                mission.missionName = "Heavy Freight Transport";
                mission.rewardBase = 15000;
                mission.rewardPerKm = 800;
                mission.timeLimit = distanceKm / 70 * 60;
                break;
        }

        mission.missionId = System.Guid.NewGuid().ToString();
        mission.distanceKm = distanceKm;
        mission.completed = false;
        
        activeMissions.Add(mission);
        Debug.Log($"Mission created: {mission.missionName} ({mission.distanceKm} km)");
    }

    public void CompleteMission(string missionId, int timeSpentMinutes)
    {
        var mission = activeMissions.Find(m => m.missionId == missionId);
        if (mission != null)
        {
            mission.completed = true;
            mission.earnedReward = CalculateMissionReward(mission, timeSpentMinutes);
            activeMissions.Remove(mission);
            completedMissions.Add(mission);
            Debug.Log($"Mission completed! Reward: {mission.earnedReward} TZS");
        }
    }

    private int CalculateMissionReward(Mission mission, int timeSpentMinutes)
    {
        int baseReward = mission.rewardBase + (mission.distanceKm * mission.rewardPerKm);
        int penalty = 0;
        
        if (timeSpentMinutes > mission.timeLimit)
        {
            int lateMinutes = timeSpentMinutes - mission.timeLimit;
            penalty = lateMinutes * mission.penaltyLatePerMinute;
        }
        
        return Mathf.Max(0, baseReward - penalty);
    }

    public int GetTotalEarnings()
    {
        int total = 0;
        foreach (var mission in completedMissions)
        {
            total += mission.earnedReward;
        }
        return total;
    }
}
