using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards SO/Card")]
public class CardsSO : ScriptableObject
{
    [SerializeField] private string animalName;
    [SerializeField] private Sprite cardImage;
    [SerializeField] private AudioClip cardAudio;

    public string AnimalName { get => animalName; set => animalName = value; }
    public Sprite CardImage { get => cardImage; set => cardImage = value; }
    public AudioClip CardAudio { get => cardAudio; set => cardAudio = value; }
}
