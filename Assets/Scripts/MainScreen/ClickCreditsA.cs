using UnityEngine;
using UnityEngine.UI;

public class ClickCreditsA : MonoBehaviour
{
    public GameObject objectToToggle;
    public Button toggleButton;

    private bool isObjectActive;

    private void Start()
    {
        // Set the initial state of the object
        objectToToggle.SetActive(isObjectActive);

        // Attach the button click event
        toggleButton.onClick.AddListener(ToggleObject);
    }

    private void ToggleObject()
    {
        // Toggle the object's active state
        isObjectActive = !isObjectActive;
        objectToToggle.SetActive(isObjectActive);
    }
}
