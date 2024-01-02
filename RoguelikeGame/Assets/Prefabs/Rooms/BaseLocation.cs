using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLocation : MonoBehaviour
{
    [SerializeField] protected GameObject[] FightSmallRooms;

    [SerializeField] protected GameObject[] FightMediumRooms;

    [SerializeField] protected GameObject[] FightArenaRooms;

    [SerializeField] protected GameObject[] RestRooms;

    [SerializeField] protected GameObject[] CraftRooms;

    protected Hashtable Rooms = new Hashtable();

    public GameObject GetRandomRoom(RoomType type)
    {
        GameObject[] rooms = (GameObject[])Rooms[type];

        return rooms[Random.Range(0, rooms.Length - 1)];
    }
}
