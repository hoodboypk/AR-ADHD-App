using UnityEngine;
using UnityEngine.UI;

public class ARModelSpawner : MonoBehaviour
{
    public GameObject[] models; // Array of models to switch between
    private int currentModelIndex = 0; // Index of the currently active model

    public Button switchButton; // Reference to the button that switches models

    void Start()
    {
        // Hide all models except the first one
        for (int i = 1; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        // Set up button click listener
        switchButton.onClick.AddListener(SwitchModel);
    }

    void SwitchModel()
    {
        // activate the current model
        models[currentModelIndex].SetActive(true);

        // Increment index to switch to the next model
        currentModelIndex = (currentModelIndex + 1) % models.Length;

        // Activate the new model
        models[currentModelIndex].SetActive(true);
    }
}