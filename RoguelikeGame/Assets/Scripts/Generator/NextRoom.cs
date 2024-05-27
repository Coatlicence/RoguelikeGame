using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NextRoom : MonoBehaviour
{
    [SerializeField] private bool _Activated = true;

    public bool GetActivated()
    {
        return _Activated;
    }

    public void SetActivated(bool activated)
    {
        _Activated = activated;

        if (NextRoomCollider)
            NextRoomCollider.enabled = activated;
        else
            Debug.LogError("NextRoomCollider is null");

        if (TestText)
        {
            if (activated)
                TestText.text = NextRoomForSpawn.ToString();
            else
                TestText.text = "";
        }
    }

    [SerializeField] Collider NextRoomCollider;

    [SerializeField] RoomType NextRoomForSpawn;

    public void SetNextRoomForSpawn(RoomType nextRoom)
    {
        NextRoomForSpawn = nextRoom;

        if (TestText) TestText.text = NextRoomForSpawn.ToString();
    }

    public RoomType GetNextRoomForSpawn()
    {
        return NextRoomForSpawn;
    }

    [SerializeField] TMP_Text TestText;

    private void Awake()
    {
        //NextRoomCollider = GetComponent<Collider>();
        TestText = GetComponentInChildren<TMP_Text>();

        if (!_Activated)
        {
            if (NextRoomCollider) NextRoomCollider.enabled = false;
            return;
        }

        if (TestText) TestText.text = NextRoomForSpawn.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(WorldGenerator._Instance.TryGetRandomRoom(LocationType.LushCaves, RoomType.FightSmall));

        WorldGenerator._Instance.Generate(NextRoomForSpawn);
    }
}
