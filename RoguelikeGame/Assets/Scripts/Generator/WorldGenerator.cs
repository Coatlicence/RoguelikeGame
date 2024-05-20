using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class WorldGenerator : MonoBehaviour
{
    //public Dictionary<Tuple<LocationType, RoomType>,>

    // 
    LocationType loc = LocationType.Seriantatum;

    // Максимальная длина 1 локации для прохождения. Всего комнат в игре
    // (Максимальное кол-во локаций) * MaxLengthOfLocation
    [SerializeField] int _MaxLengthOfLocation;

    // Разброс по кол-ву комнат на 1 локацию
    [SerializeField] int _SpreadOfLength;

    // Данная переменная проверяет, когда нужно переходить на следущую локацию
    int _CurrentLengthOfLocation;

    private void Awake()
    {
        //_CurrentLengthOfLocation = _MaxLengthOfLocation + UnityEngine.Random.Range(-_SpreadOfLength, _SpreadOfLength);

        //Debug.Log(loc);
        //loc++;
        //Debug.Log(loc);
    }

    public bool GenerateRoom(RoomType type) 
    {
        return false;

        //SceneManager.LoadScene
    }

}
