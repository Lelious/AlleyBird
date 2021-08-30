using UnityEngine;

public class RunningCatMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject parentGameObject;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(speed * Time.deltaTime, _rigidBody.velocity.y);

        if (!_spriteRenderer.isVisible)
        {
            Destroy(parentGameObject);
        }
    }

    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name.Contains("VerticalPlatformRight") && !_spriteRenderer.flipX)
    //    {
    //        _spriteRenderer.flipX = true;
    //        speed = -150;
    //    }

    //    else if (collision.gameObject.name.Contains("VerticalPlatformLeft") && _spriteRenderer.flipX)
    //    {
    //        _spriteRenderer.flipX = false;
    //        speed = 150;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("VerticalPlatformRight") && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
            speed = -150;
        }

        else if (collision.gameObject.name.Contains("VerticalPlatformLeft") && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
            speed = 150;
        }
    }
}
