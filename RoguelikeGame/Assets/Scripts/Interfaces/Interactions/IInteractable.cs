using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class to interact player with any object
/// </summary>
public abstract class IInteractable : MonoBehaviour
{
    /// <summary>
    /// method to interact player with some gameobject
    /// </summary>
    /// <param name="activator"> </param>
    public abstract void Interact(StandartController activator);
}
