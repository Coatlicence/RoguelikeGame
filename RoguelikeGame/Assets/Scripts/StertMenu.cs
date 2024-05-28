using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StertMenu : MonoBehaviour
{
    private void OnEnable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.MENU);
    }
    private void OnDisable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);
    }
}
