using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public float gridSize = 1.0f; // Adjust this value to set the size of the grid

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SnapPositionToGrid();
            }
        }
    }

    void SnapPositionToGrid()
    {
        Vector3 newPosition = transform.position;

        // Snap each coordinate to the nearest grid point
        newPosition.x = Mathf.Round(newPosition.x / gridSize) * gridSize;
        newPosition.y = Mathf.Round(newPosition.y / gridSize) * gridSize;
        newPosition.z = Mathf.Round(newPosition.z / gridSize) * gridSize;

        // Update the object's position
        transform.position = newPosition;
    }
}
