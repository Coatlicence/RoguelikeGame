using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LushCaves : BaseLocation
{
    public static LushCaves singleton { get; private set; }

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }

        Rooms.Add(RoomType.FightSmall,  FightSmallRooms);
        Rooms.Add(RoomType.FightMedium, FightMediumRooms);
        Rooms.Add(RoomType.FightArena,  FightArenaRooms);
        Rooms.Add(RoomType.Restroom,    RestRooms);
        Rooms.Add(RoomType.Craftroom,   CraftRooms);

    }   
}
