using UnityEngine;

public class ARModelController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 touchStartPosition;
    private Vector3 touchOffset;

    void Update()
    {
        // Check if there is touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Check if touch begins on the model
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit))
                    {
                        if (hit.collider.gameObject != gameObject)
                            return;


                        isDragging = true;
                        touchStartPosition = touch.position;
                        touchOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

                    }
                    break;
                case TouchPhase.Moved:
                    // Move the model if dragging
                    if (isDragging)
                    {
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)) + touchOffset;
                        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
                    }
                    break;
                case TouchPhase.Ended:
                    // End dragging
                    isDragging = false;
                    break;
            }
        }
    }
}
