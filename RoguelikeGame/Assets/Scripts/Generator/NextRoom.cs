using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NextRoom : MonoBehaviour
{
    [SerializeField] Collider NextRoomCollider;

    [SerializeField] RoomType NextRoomForSpawn;

    [SerializeField] TMP_Text TestText;

    private void Awake()
    {
        NextRoomCollider = GetComponent<Collider>();
        TestText = GetComponentInChildren<TMP_Text>();

        if (TestText) TestText.text = NextRoomForSpawn.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(WorldGenerator._Instance.TryGetRandomRoom(LocationType.LushCaves, RoomType.FightSmall));

        WorldGenerator._Instance.SpawnPlayerInNewRoom(NextRoomForSpawn);
    }
}
