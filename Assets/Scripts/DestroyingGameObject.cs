using UnityEngine;

public class DestroyingGameObject : MonoBehaviour
{
    private void Awake()
    {
        Invoke("Destroy", 1f);           
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
