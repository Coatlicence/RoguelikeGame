using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayOfRooms : MonoBehaviour
{
    public static ArrayOfRooms singleton = null;

    Hashtable Locations = new Hashtable();
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

        Locations.Add(LocationType.LushCaves, LushCaves.singleton);
    }

    public GameObject GetRoom(LocationType location, RoomType room)
    {
        BaseLocation Location = (BaseLocation)Locations[location];

        return Location.GetRandomRoom(room);
    }
}
