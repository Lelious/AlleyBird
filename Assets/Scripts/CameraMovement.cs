using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private float offset = 0f;
    private void FixedUpdate()
    {
        transform.position = new Vector3(0, playerTransform.position.y, -1);
    }
}
