using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public GameObject runningCatSpawner;
    public Transform platformTransform;

    void Awake()
    {
        platformTransform = GetComponent<Transform>();
    }
}
