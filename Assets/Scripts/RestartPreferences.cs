using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPreferences : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
