using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARModelSpawner : MonoBehaviour
{
    public GameObject[] arModels; // Array to hold all the AR models
    public GameObject spawnButton; // Reference to the spawn button

    private int currentIndex = 0; // Index of the currently enabled model

    private void Start()
    {
        // Disable all AR models at the start
        foreach (GameObject model in arModels)
        {
            model.SetActive(false);
        }

        // Disable the spawn button at the start
        spawnButton.SetActive(false);
    }

    // Method to be called when the spawn button is clicked
    public void SpawnModels()
    {
        if (currentIndex < arModels.Length)
        {
            arModels[currentIndex].SetActive(true); // Enable the current AR model
            currentIndex++; // Move to the next model

            if (currentIndex >= arModels.Length)
            {
                spawnButton.SetActive(false); // Disable the spawn button when all models are spawned
            }
        }
    }
}
