using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class WorldGenerator : MonoBehaviour
{
    // тест
    [SerializeField] LocationType LocationType;

    [SerializeField] int MaxLengthOfLocation;

    [SerializeField] int SpreadOfLength;

    int CurrentLengthOfLocation;

    private void Awake()
    {
        CurrentLengthOfLocation = MaxLengthOfLocation + (int)Random.Range(-SpreadOfLength, SpreadOfLength);
    }

    public bool GenerateRoom(RoomType type) 
    {
        if (CurrentLengthOfLocation < 0)
        {
            NextLocation();
            return false;
        }
            
                
        return true;
    }

    private void NextLocation()
    {
        LocationType++;

        CurrentLengthOfLocation = MaxLengthOfLocation + (int)Random.Range(-SpreadOfLength, SpreadOfLength);
    }
}
