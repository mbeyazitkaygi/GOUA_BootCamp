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
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        if (distance <= clampDistance)
        {
            moveToStartPos = false;
            moveToEndPos = false;
        }

        float movementAmount = moveSpeed * Time.deltaTime;

        if (movementAmount > distance)
        {
            movementAmount = distance;
        }

        transform.position += direction.normalized * movementAmount;

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
