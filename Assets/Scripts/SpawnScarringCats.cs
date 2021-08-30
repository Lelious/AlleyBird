using UnityEngine;

public class SpawnScarringCats : MonoBehaviour
{
    [SerializeField] private GameObject scaringCat;
    [SerializeField] private GameObject attentionSign;
    private void Awake()
    {
        InvokeRepeating("SpawnScarryCat", 1f, 4f);
        InvokeRepeating("SpawnAttentionImage", 0, 4f);
    }

    private void SpawnScarryCat()
    {
        Instantiate(scaringCat, gameObject.transform);
    }

    private void SpawnAttentionImage()
    {
        Instantiate(attentionSign, gameObject.transform);
    }
}
