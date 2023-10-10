using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelSwapper : MonoBehaviour
{
    [Header("CURRENT PANEL")]
    [SerializeField] private GameObject panel;
    [SerializeField] private string panelTrigger;
    [SerializeField] private AnimationClip panelAnimation;

    [Header("NEXT PANEL")]
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private string nextPanelTrigger;
    [SerializeField] private bool activated = false;

    private Button button;

    private Animator panelAnimator;
    private Animator nextPanelAnimator;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Swap);

        panelAnimator = panel.GetComponent<Animator>();

        nextPanelAnimator = nextPanel.GetComponent<Animator>();

        nextPanel.SetActive(activated);
    }

    private void Swap()
    {
        StartCoroutine(SwapCoroutine());
    }

    private IEnumerator SwapCoroutine()
    {
        panelAnimator.SetTrigger(panelTrigger);
        yield return new WaitForSeconds(panelAnimation.length);
        panel.SetActive(false);

        nextPanel.SetActive(true);
        nextPanelAnimator.SetTrigger(nextPanelTrigger);
    }

}
