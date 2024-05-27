using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.MLAgents;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] RoomType type;
    public RoomType GetRoomType() { return type; }


    [SerializeField] List<NextRoom> NextRooms;
    public List<NextRoom> GetListOfNextRoomTriggers()
    {
        return NextRooms;
    }

    public GameObject[] CratePositions;

    public GameObject[] ObstaclePositions;

    public Transform _PlayerPosition;

    private void FindNextRoomTriggers(Transform parent)
    {
        var trigger = parent.GetComponent<NextRoom>();
        if (trigger)
        {
            NextRooms.Add(trigger);
            return;
        }

        if (parent.childCount == 0)
            return;

        for (int i = 0; i < parent.childCount; i++)
        {
            FindNextRoomTriggers(parent.GetChild(i));
        }
    }

    public void FindAllReferences()
    {
        CratePositions      = GameObject.FindGameObjectsWithTag("Room_CratePosition");
        ObstaclePositions   = GameObject.FindGameObjectsWithTag("Room_ObstaclePosition");

        GameObject.FindObjectsOfType<Item>();

        FindNextRoomTriggers(gameObject.transform);
    }    

}
