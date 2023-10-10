using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards SO/Card")]
public class CardsSO : ScriptableObject
{
    [SerializeField] string animalName;
    [SerializeField] Sprite cardImage;
    [SerializeField] AudioClip cardAudio;

    public string AnimalName => animalName;
    public Sprite CardImage => cardImage;
    public AudioClip CardAudio => cardAudio;
}
