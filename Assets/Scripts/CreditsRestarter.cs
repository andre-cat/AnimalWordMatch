using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsRestarter : MonoBehaviour
{
    [SerializeField] private SlidingScrollView slidingScrollView;

    private void RestartCredits()
    {
        slidingScrollView.Scrollbar.value = slidingScrollView.InitialValue;
    }
}
