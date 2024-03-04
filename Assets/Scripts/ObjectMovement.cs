using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private void Update()
    {
        // Check for touch or mouse input to move the object
        if (Input.GetMouseButton(0))
        {
            // Get the current screen position of the touch/mouse
            Vector3 touchPosition = Input.mousePosition;
            touchPosition.z = 10f; // Set a distance from the camera

            // Convert the screen position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Move the object to the new position
            transform.position = worldPosition;

            // Perform a raycast downwards to check for collisions with the ground/base
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                // If the raycast hits something, adjust the object's position
                float distanceToGround = hit.distance;
                if (distanceToGround < 1f) // Adjust this threshold as needed
                {
                    transform.position += Vector3.up * (1f - distanceToGround);
                }
            }
        }
    }
}
