using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject textcardPrefab;
    [SerializeField] CardsListSO cardList;
    List<CardController> cardControllers;
    CardController firstCardClicked;
    [SerializeField] AudioSource voiceAudioSource;
    [SerializeField] AudioClip[] failAudios;
    private int hiddenCardCount = 0;


    void OnEnable()
    {
        cardControllers = new List<CardController>();
        GenerateCards();
        StartCoroutine(RevealAllCards());

    }

    private void Update()
    {
        FindHiddenCount();
    }

    void GenerateCards()
    {
        int cardCount = 8;
        List<CardsSO> availableCards = new(cardList.Cards);

        string animalsImages = "#";
        string animalsTexts = "#";

        for (int i = 0; i < cardCount; i++)
        {
            // First Card: Display Image
            GameObject cardWithImage = Instantiate(cardPrefab, transform);
            cardWithImage.transform.name = $"Card ({i})";
            CardController imageCardController = cardWithImage.GetComponent<CardController>();

            int randomIndex;

            randomIndex = Random.Range(0, cardCount);

            while (animalsImages.Contains($"#{randomIndex:D2}#"))
            {
                randomIndex = Random.Range(0, availableCards.Count);
            }

            animalsImages += $"{randomIndex:D2}#";

            CardsSO selectedCardWithImage = availableCards[randomIndex];

            imageCardController.cardSO = selectedCardWithImage;
            //availableCards.RemoveAt(randomIndex);

            cardControllers.Add(imageCardController);

            // Second Card: Display Animal Name
            GameObject cardWithAnimalName = Instantiate(textcardPrefab, transform);
            cardWithAnimalName.transform.name = $"Card ({i})";
            CardController nameCardController = cardWithAnimalName.GetComponent<CardController>();

            randomIndex = Random.Range(0, cardCount);

            while (animalsTexts.Contains($"#{randomIndex:D2}#"))
            {
                randomIndex = Random.Range(0, availableCards.Count);
            }

            animalsTexts += $"{randomIndex:D2}#";

            // Assign the animal name to the CardController
            nameCardController.cardSO = ScriptableObject.CreateInstance<CardsSO>();
            //nameCardController.cardSO.AnimalName = selectedCardWithImage.AnimalName;
            nameCardController.cardSO.AnimalName = availableCards[randomIndex].AnimalName;
            nameCardController.cardSO.CardImage = null; // Set the image to null or a default image for the second card

            cardControllers.Add(nameCardController);
        }

    }

    
            
    IEnumerator RevealAllCards()
    {
        foreach (var card in cardControllers)
        {
            card.FlipCard(); // Flip the card to reveal the front
        }

        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        foreach (var card in cardControllers)
        {
            card.FlipCard(); // Flip the card back to hide the front
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
                // Cards match
                voiceAudioSource.PlayOneShot(clickedCard.cardSO.CardAudio);
                StartCoroutine(MatchFoundRoutine(firstCardClicked, clickedCard));
            }
            else
            {
               
                int ranInt = Random.Range(0, failAudios.Length);
                // Cards do not match, flip back the cards after a delay
                voiceAudioSource.PlayOneShot(failAudios[ranInt]);
                StartCoroutine(FlipBackCards(firstCardClicked, clickedCard));
            }

            // Reset the first clicked card
            firstCardClicked = null;

           
        }
    }

    private void FindHiddenCount()
    {
        hiddenCardCount = 0; // Reset the hidden card count variable

        foreach (var card in cardControllers)
        {
            if (card.isHidden)
            {
                hiddenCardCount++;
            }
        }

        if (hiddenCardCount == 16)
        {
            GameManager.GameOver = true;
        }
    }






    private IEnumerator MatchFoundRoutine(CardController card1, CardController card2)
    {
        yield return new WaitForSeconds(1f); // Adjust the delay time as needed

        card1.DestroyCard(); // Destroy the first card
        card2.DestroyCard(); // Destroy the second card
    }

    private IEnumerator FlipBackCards(CardController card1, CardController card2)
    {
        yield return new WaitForSeconds(1f); // Adjust the delay time as needed

        card1.FlipCard(); // Flip back the first card
        card2.FlipCard(); // Flip back the second card
    }
}

