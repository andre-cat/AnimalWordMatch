using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameObject cardPrefab;
    [SerializeField] CardsListSO cardList;
    List<CardController> cardControllers;
    public void Awake()
    {
        cardControllers = new List<CardController>();
        GenerateCards();
    }
    private void GenerateCards()
    {
        int cardCount = 16;
        for (int i = 0; i < cardCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, this.transform);
            card.transform.name = $"Card ({i.ToString()})";
            cardControllers.Add(card.GetComponent<CardController>());
        }
    }
}
