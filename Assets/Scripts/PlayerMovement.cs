using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _doubleJumpPower;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _stars;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isCanDoubleJump;
    private bool _isDoubleJumped;
    private bool _isGrounded = true;
    private bool _isDead;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && !_isCanDoubleJump && !_isDead)
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                Jump(_jumpPower);
                _animator.Play("BirdFly");
            }
        }

        if (Input.touchCount > 0 && _isCanDoubleJump && !_isGrounded && !_isDoubleJumped && !_isDead)
        {
            Jump(_doubleJumpPower);
            _isDoubleJumped = true;
            _isCanDoubleJump = false;
        }

        if (Input.touchCount == 0 && !_isGrounded && !_isCanDoubleJump && !_isDead)
        {
            _isCanDoubleJump = true;
        }
    }
    private void FixedUpdate()
    {
        if (!_isDead)
        {
            _rigidBody.velocity = new Vector2(1 * _speed * Time.deltaTime, _rigidBody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("VerticalPlatformRight") && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
            _speed = -150;
        }

        else if (collision.gameObject.name.Contains("VerticalPlatformLeft") && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
            _speed = 150;
        }

        else if (collision.gameObject.name.Contains("HorizontalPlatform") && _rigidBody.velocity.y <= 0 && !_isDead)
        {
            _isDoubleJumped = false;
            _isGrounded = true;
            _isCanDoubleJump = false;
            _animator.Play("BirdWalk");
        }
    }

    private void Jump(float jumpPower)
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpPower);
    }

    public void PlayerDeath()
    {
        _isDead = true;
        _rigidBody.velocity = Vector2.zero;
        _animator.Play("BirdDeath");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        Invoke("ShowLoseMenu", 1f);
    }

    private void ShowLoseMenu()
    {
        _loseMenu.SetActive(true);
        _stars.SetActive(true);
    }
}
