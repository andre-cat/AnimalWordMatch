using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class SlidingScrollView : MonoBehaviour
{

    [SerializeField][Min(0)] private float initialValue;
    [SerializeField][Min(0)] private float reloadValue;
    [SerializeField][Min(0)] private float speed;

    private Scrollbar scrollbar;

    public Scrollbar Scrollbar
    {
        get => scrollbar;
    }

    public float InitialValue
    {
        get => initialValue;
    }

    private void OnEnable()
    {
        RestartCredits();
    }

    private void FixedUpdate()
    {
        if (scrollbar.value <= 0)
        {
            scrollbar.value = reloadValue;
        }
        else
        {
            scrollbar.value -= speed;
        }
    }

    private void RestartCredits()
    {
        scrollbar = gameObject.GetComponent<Scrollbar>();
        scrollbar.value = initialValue;
    }
}
