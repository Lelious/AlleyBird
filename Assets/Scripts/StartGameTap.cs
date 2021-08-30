using UnityEngine;

public class StartGameTap : MonoBehaviour
{
    [SerializeField] private GameObject _statsCanvas;
    [SerializeField] private GameObject _startCanvas;

    private PlayerMovement _playerMovement;
    private static bool _isGameStarted;
    private static bool _isFirstTouch;
    private GameObject _bird;
    private void Awake()
    {
        _bird = GameObject.FindGameObjectWithTag("Bird");
        _playerMovement = _bird.GetComponent<PlayerMovement>();

        if (_isGameStarted)
        {
            _startCanvas.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0 && !_isFirstTouch)
        {
            FirstTouch();
        }
    }

    public void FirstTouch()
    {
        _playerMovement.GetComponent<PlayerMovement>().enabled = true;
        _isFirstTouch = true;
        _statsCanvas.SetActive(true);
        _startCanvas.SetActive(false);
        _playerMovement.enabled = true;
        _isGameStarted = true;
    }
}
