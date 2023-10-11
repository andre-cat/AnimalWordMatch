using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    
    public CardsSO cardSO;
    private Button button;

    [SerializeField] private TMP_Text textField;
    [SerializeField] private Image bgImage;
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;


    //[SerializeField] private AudioSource audioSource;

    private void Start()
    {


        AssignCardInfo();
        button = gameObject.GetComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(Click);
    }

   

    private void AssignCardInfo()
    {
        if (cardSO.CardImage != null)
        {
            // Check if the front has an Image component
            Image imageComponent = front.GetComponent<Image>();
            if (imageComponent != null)
            {
                // Set the front sprite using the cardSO sprite
                imageComponent.sprite = cardSO.CardImage;
            }

        }
        else
        {
            // Set the TextMeshPro text using the cardSO AnimalName
            textField.text = cardSO.AnimalName;
        }
    }
    void Click()
    {
        Debug.Log(this.cardSO.AnimalName);
    }

}

