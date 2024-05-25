using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class Recipe
{
    public List<Type> ingridients = new List<Type>();
    public Type Rezult;
}
