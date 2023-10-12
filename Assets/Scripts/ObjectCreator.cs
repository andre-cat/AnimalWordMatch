using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{

    [SerializeField] new private GameObject gameObject;
    [SerializeField] private Transform parent;

    private void CreateObject()
    {
        Instantiate(gameObject, parent);
    }
}
