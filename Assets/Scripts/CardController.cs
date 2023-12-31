using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class CardController : MonoBehaviour
{

    public CardsSO cardSO;
    private Button button;

    [SerializeField] private TMP_Text textField;
    [SerializeField] private Image bgImage;
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;
    [SerializeField] ParticleSystem stars;
    private bool isFlipped = false;
    public bool isHidden = false;

    CanvasManager canvasManager;

    private static float flipTime = 0.5f;

    public static float FlipTime {get=> flipTime;}

    private void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();

        AssignCardInfo();

        button = gameObject.GetComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(Click);

        stars.gameObject.SetActive(false);
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
        StartCoroutine(FlipCardCoroutine(flipTime));
    }

    private IEnumerator FlipCardCoroutine(float seconds)
    {

        isFlipped = !isFlipped;

        int initialRotation;
        int finalRotation;

        if (isFlipped)
        {
            initialRotation = 0;
            finalRotation = 180;
        }
        else
        {
            initialRotation = 180;
            finalRotation = 0;
        }

        float secondsElapsed = 0;

        bool wasFlipped = false;

        while (secondsElapsed < seconds)
        {
            float t = secondsElapsed / seconds;
            
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(0, initialRotation, 0)), Quaternion.Euler(new Vector3(0, finalRotation, 0)), Mathf.Clamp01(t));
            
            if (!wasFlipped & t > 0.49f)
            {
                wasFlipped = true;
                front.SetActive(isFlipped);
                back.SetActive(!isFlipped);
            }
            
            secondsElapsed += Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, finalRotation, 0));
    }

    public void ChangeAlphaRecursively(GameObject obj, float alpha)
    {

        // Get the Image component of the GameObject
        Image image = obj.GetComponent<Image>();

        // Get the TextMeshPro component of the GameObject
        TMPro.TextMeshProUGUI textMesh = obj.GetComponent<TMPro.TextMeshProUGUI>();

        // Check if either Image or TextMeshPro component exists
        if (image != null)
        {
            // Get the current color
            Color currentColor = image.color;

            // Set the alpha value
            currentColor.a = alpha;

            // Assign the modified color back to the Image component
            image.color = currentColor;
        }
        else if (textMesh != null)
        {
            // Get the current color
            Color currentColor = textMesh.color;

            // Set the alpha value
            currentColor.a = alpha;

            // Assign the modified color back to the TextMeshPro component
            textMesh.color = currentColor;
        }

        // Recursively process child objects
        foreach (Transform child in obj.transform)
        {
            ChangeAlphaRecursively(child.gameObject, alpha);
        }

        isHidden = true;
    }


    public void DestroyCard()
    {
        int numberOfCards = GameObject.FindGameObjectsWithTag("Card").Length;

        if (numberOfCards - 1 == 0)
        {
            GameManager.GameOver = true;
        }

        // Change alpha value of the current object and its children
        ChangeAlphaRecursively(gameObject, 0f);
    }

    public IEnumerator PlayParticles(){
        stars.gameObject.SetActive(true);
        stars.Play();
        yield return new WaitForSeconds(1f);
        stars.gameObject.SetActive(false);
    }
}

