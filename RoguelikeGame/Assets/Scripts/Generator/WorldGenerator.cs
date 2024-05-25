using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WorldGenerator : MonoBehaviour
{
    public static WorldGenerator _Instance;

    public GameObject OldRoom;

    public List<RoomPair> AllRooms = new();
    

    [SerializeField]
    LocationType CurrentLocation = LocationType.Seriantatum;

    // Максимальная длина 1 локации для прохождения. Всего комнат в игре
    // (кол-во локаций) * _MaxLengthOfLocation + (0; _SpreadOfLength)
    [SerializeField] int _MaxLengthOfLocation = 20;

    // Разброс по кол-ву комнат на 1 локацию
    [SerializeField] int _SpreadOfLength = 5;

    // Данная переменная проверяет, когда нужно переходить на следущую локацию
    //int _CurrentLengthOfLocation = 0;

    void Awake()
    {
        if (_Instance == null)
        { 
            _Instance = this; 
        }
        else if (_Instance == this)
        { 
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SpawnPlayerInNewRoom(RoomType room)
    {
        Destroy(OldRoom);


    }

    public GameObject GetRandomRoom(LocationType loc, RoomType room)
    {
        List<GameObject> rooms = new();

        foreach (RoomPair roomPair in AllRooms)
        {
            if (roomPair.Room == room && roomPair.Location == loc)
                rooms = roomPair.Rooms;
        }

        if (rooms.Count == 0)
        {
            Debug.LogError($"There is no Rooms for {loc} and {room} pair");
            return null;
        }

        return rooms[UnityEngine.Random.Range(0, rooms.Count)];
    }

    // Only for test
    public GameObject TryGetRandomRoom(LocationType loc, RoomType roomType)
    {
        int attempts = 100;
        GameObject room = null;
        while (!room && attempts > 0) 
        {
            room = GetRandomRoom(loc, roomType);
            attempts--;
        }

        if (!room) Debug.LogError($"Cant find room");


        return room;
    }

    public bool GenerateRoom(RoomType type) 
    {
        return false;

        //SceneManager.LoadScene
    }

}

[Serializable] 
public class RoomPair
{
    public LocationType    Location;
    public RoomType        Room;

    public List<GameObject> Rooms = new();
}