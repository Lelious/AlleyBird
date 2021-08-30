using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoadScene : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Text loadingText;

    private float loadingSpeed = 1;
    private float targetValue;
    private AsyncOperation operation;

    void Awake()
    {       
        loadingSlider.value = 0.0f;

        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync("GameScene");        
        operation.allowSceneActivation = false;
        loadingSlider.enabled = true;

        yield return operation;
    }

    void Update()
    {
        targetValue = operation.progress;

        if (operation.progress >= 0.9f)
        {
            targetValue = 1.0f;
        }

        if (targetValue != loadingSlider.value)
        {
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
            {
                loadingSlider.value = targetValue;
            }
        }

        loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";

        if ((int)(loadingSlider.value * 100) == 100)
        {
            operation.allowSceneActivation = true;
        }
    }
}

