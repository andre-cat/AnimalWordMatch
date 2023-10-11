using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "Cards SO/List")]
public class CardsListSO : ScriptableObject
{
    [SerializeField] private List<CardsSO> cards = new List<CardsSO>();
    public List<CardsSO> Cards => cards;
}
