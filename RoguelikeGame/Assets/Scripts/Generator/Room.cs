using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] RoomType type;

    [SerializeField] List<GameObject> NextRooms;

    private void Awake()
    {
        //Find
    }

    void Start()
    {
        
    }

    public RoomType GetRoomType() { return type; }
}
