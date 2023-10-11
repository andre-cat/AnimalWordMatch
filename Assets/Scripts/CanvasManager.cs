using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject textcardPrefab;
    [SerializeField] CardsListSO cardList;
    List<CardController> cardControllers;
    CardController firstCardClicked;


    void Awake()
    {
        cardControllers = new List<CardController>();
        GenerateCards();
    }


    void GenerateCards()
    {
        int cardCount = 8;
        List<CardsSO> availableCards = new List<CardsSO>(cardList.Cards);

        for (int i = 0; i < cardCount; i++)
        {
            // First Card: Display Image
            GameObject cardWithImage = Instantiate(cardPrefab, transform);
            cardWithImage.transform.name = $"Card ({i.ToString()})";
            CardController imageCardController = cardWithImage.GetComponent<CardController>();

            int randomIndex = Random.Range(0, availableCards.Count);
            CardsSO selectedCardWithImage = availableCards[randomIndex];

            imageCardController.cardSO = selectedCardWithImage;
            availableCards.RemoveAt(randomIndex);

            cardControllers.Add(imageCardController);

            // Second Card: Display Animal Name
            GameObject cardWithAnimalName = Instantiate(textcardPrefab, transform);
            cardWithAnimalName.transform.name = $"Card ({i.ToString()})";
            CardController nameCardController = cardWithAnimalName.GetComponent<CardController>();

            // Assign the animal name to the CardController
            nameCardController.cardSO = ScriptableObject.CreateInstance<CardsSO>();
            nameCardController.cardSO.AnimalName = selectedCardWithImage.AnimalName;
            nameCardController.cardSO.CardImage = null; // Set the image to null or a default image for the second card

            cardControllers.Add(nameCardController);
        }
    }

    public void CardClicked(CardController clickedCard)
    {
        if (firstCardClicked == null)
        {
            firstCardClicked = clickedCard;
        }
        else
        {
            // Check if the cards match
            if (firstCardClicked.cardSO.AnimalName == clickedCard.cardSO.AnimalName)
            {
                // Cards match, perform your logic here
                firstCardClicked.DestroyCard();
                clickedCard.DestroyCard();
                Debug.Log("Match found!");
            }
            else
            {
                // Cards do not match, perform your logic here (e.g., flip back the cards)
                Debug.Log("No match, flip back the cards.");
            }

            // Reset the first clicked card
            firstCardClicked = null;
        }
    }
}

