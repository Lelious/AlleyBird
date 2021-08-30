using UnityEngine;

public class ScaringCatMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject parentGameObject;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(speed * Time.deltaTime, _rigidBody.velocity.y);

        if (!spriteRenderer.isVisible)
        {
            Destroy(parentGameObject);
        }
    }
}
