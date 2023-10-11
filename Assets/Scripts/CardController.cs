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
    private bool isFlipped = false;

    CanvasManager canvasManager;



    //[SerializeField] private AudioSource audioSource;

    private void Start()
    {

        canvasManager = FindObjectOfType<CanvasManager>();

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
        if (!isFlipped)
        {
            FlipCard();
            canvasManager.CardClicked(this);
        }
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        front.SetActive(isFlipped);
        back.SetActive(!isFlipped);
    }
    public void DestroyCard()
    {
        int numberOfCards = GameObject.FindGameObjectsWithTag("Card").Length;

        if (numberOfCards - 1 == 0)
        {
            GameManager.GameOver = true;
        }

        Destroy(gameObject);
    }

}

