using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum TrialResult
{
    NotStarted,
    Completed,
    Failed
}

public class GameTrials : MonoBehaviour
{
    static GameTrials _Instance;

    public static GameTrials GetInstance()
    {
        return _Instance;
    }

    List<Trial> _Trials = new();
    List<Reward> _Rewards = new();
    List<Reward> _Punishes = new();

    delegate Task<TrialResult> Trial(int millisecs);

    delegate void Reward();

    GameTrials()
    {
        /// Trials
        _Trials.Add(TrialDestroyAllCratesIn);

        /// Rewards
        _Rewards.Add(RewardAddItem);

        /// Punishes
        _Punishes.Add(PunishMakeSlower);
    }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
            Destroy(gameObject);
        else
            _Instance = this;
    }

    public async void StartRandomTrial()
    {
        if (_Trials.Count <= 0)
        {
            Debug.LogError("There is no any trials in _Trials[]");
            return;
        }

        var room = WorldManager._Instance._CurrentLevel.GetComponent<Room>();

        if (room.GetRoomType() != RoomType.FightSmall)
            return;

        // Starting Trial
        var result = await _Trials[Random.Range(0, _Trials.Count)](10000);

        switch (result)
        {
            case TrialResult.NotStarted:
                return;

            case TrialResult.Failed:
                if (_Punishes.Count > 0) _Punishes[Random.Range(0, _Punishes.Count)]();
                break;

            case TrialResult.Completed:
                if (_Rewards.Count > 0) _Rewards[Random.Range(0, _Rewards.Count)]();
                break;
        }
    }

    /// Trials
    async Task<TrialResult> TrialDestroyAllCratesIn(int millisecs)
    {
        // check the possibility of starting the trial
        if (FindObjectsOfType<LootTable>().Length < 0)
        {
            Debug.Log("No Crates in scene");
            return TrialResult.NotStarted;
        }

        Debug.Log("Waiting 10 secs");

        // give some time to player
        await Task.Delay(millisecs);

        // check for condition
        if (FindObjectsOfType<LootTable>().Length == 0)
        {
            Debug.Log("Trial completed");
            return TrialResult.Completed;
        }
        else
        {
            Debug.Log("Trial failed");
            return TrialResult.Failed;
        }
    }

    /// Reward
    
    private void RewardAddItem()
    {
        _PlayerController._Instance.GetComponent<Inventory>().Add(typeof(Emerald));
    }

    /// Punishes
    
    private void PunishMakeSlower() 
    {
        var movable = _PlayerController._Instance.GetComponent<Movable>();

        movable.SetSpeed(1);
    }
}
