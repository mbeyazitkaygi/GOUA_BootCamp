using UnityEngine;
using UnityEngine.UI;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraStartPos;
    [SerializeField] private Transform cameraEndPos;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float clampDistance = 0.1f;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas selectionCanvas;

    private bool moveToStartPos = false;
    private bool moveToEndPos = false;

    private void Start()
    {
        if (selectionCanvas != null)
        {
            selectionCanvas.enabled = false;
        }
    }
    private void Update()
    {
        // Move the camera towards the end position
        if (moveToEndPos)
        {
            MoveCamera(cameraEndPos.position, cameraEndPos.rotation);
        }

        // Move the camera towards the start position
        if (moveToStartPos)
        {
            MoveCamera(cameraStartPos.position, cameraStartPos.rotation);
        }
    }

    private void MoveCamera(Vector3 targetPosition, Quaternion targetRotation)
    {
        // Calculate the direction and distance to the target position
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        // Check if camera has reached the target position
        if (distance <= clampDistance)
        {
            moveToStartPos = false;
            moveToEndPos = false;
        }

        // Calculate the movement amount based on moveSpeed and frame time
        float movementAmount = moveSpeed * Time.deltaTime;

        // Apply movement clamping
        if (movementAmount > distance)
        {
            movementAmount = distance;
        }

        // Move the camera towards the target position
        transform.position += direction.normalized * movementAmount;

        // Smoothly rotate the camera towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
    public void MoveToCam()
    {
        moveToEndPos = true;
        moveToStartPos = false;

        if (menuCanvas != null)
        {
            menuCanvas.enabled = false;
        }

        if (selectionCanvas != null)
        {
            selectionCanvas.enabled = true;
        }
    }
    public void BackToCam()
    {
        moveToStartPos = true;
        moveToEndPos = false;

        if (menuCanvas != null)
        {
            menuCanvas.enabled = true;
        }

        if (selectionCanvas != null)
        {
            selectionCanvas.enabled = false;
        }


    }
}
