using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* 
 * √лобальное хранилище необходимых переменных дл€ процедурной генерации пещер.
 * 
 * ’ранит в себе: уровень пещер, текущую и предыдущие точки дл€ генерации,
 * шанс по€влени€ гигантских комнат,
 * сложность игры, награды в комнатах.
 */
public class WorldGenerator : MonoBehaviour
{
    // ”ровень пещер, сопоставл€етс€ с уровнем комнат.
    [SerializeField] LocationType LocationType;

    [SerializeField] int MaxLengthOfLocation;

    [SerializeField] int SpreadOfLength;

    int CurrentLengthOfLocation;

    private void Awake()
    {
        CurrentLengthOfLocation = MaxLengthOfLocation + (int)Random.Range(-SpreadOfLength, SpreadOfLength);
    }

    public bool GenerateRoom(RoomType type) // true - успешна€ генераци€ комнаты
    {
        if (CurrentLengthOfLocation < 0)
        {
            NextLocation();
            return false;
        }
            
                
        // учитываем текущую локацию, сложность игры (награды и сложность комнат с монстрами) и тип комнаты
        return true;
    }

    private void NextLocation()
    {
        LocationType++; // 4 если сериантаурум, идет дальше.  од находитс€ в альфа состо€нии

        CurrentLengthOfLocation = MaxLengthOfLocation + (int)Random.Range(-SpreadOfLength, SpreadOfLength);
    }
}
