using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToggleImage : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
       gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
