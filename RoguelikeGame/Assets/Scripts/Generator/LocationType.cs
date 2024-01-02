using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum LocationType
{
    /* 
     * Полные воды, растительности и опасных животных
     * Присутствуют также карстовые пещеры с ядом.
     */
    LushCaves,

    /*
     * Пещерный город
     */
    Chernostern,

    /*
     * Вулканические пещеры, которые перемешаны с ледяными. Темные
     */
    DarkVolcanicIceCaves,

    /*
     * Пещерный футуристический город
     */
    Seriantaurum
}
