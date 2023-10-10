using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelActivator : MonoBehaviour
{
    [SerializeField] private Image panel;

    private Button button;

    private void Start()
    {
        panel.gameObject.SetActive(false);

        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Activate);
    }

    public void Activate()
    {
        panel.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}
