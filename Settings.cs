using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
