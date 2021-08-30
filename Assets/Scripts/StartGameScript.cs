using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject asyncLoad;
    [SerializeField] private GameObject progressSlider;


    private void Awake()
    {      
        Invoke("EnableExplosion", 2f);
        Invoke("EnableSlider", 4f);
    }

    private void EnableExplosion()
    {
        explosion.SetActive(true);
    }

    private void EnableSlider()
    {
        progressSlider.SetActive(true);
        asyncLoad.SetActive(true);
    }
}
