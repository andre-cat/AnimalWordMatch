using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{

    [SerializeField] new private GameObject gameObject;
    [SerializeField] private Transform parent;
    [SerializeField] private float delay;

    public void CreateObject()
    {
        StartCoroutine(CreateObjectCoroutine());
    }

    private IEnumerator CreateObjectCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(gameObject, parent);
    }
}
