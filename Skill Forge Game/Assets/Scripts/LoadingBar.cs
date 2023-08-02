using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;

    public GameObject bar;

    [SerializeField] private TextMeshProUGUI loadValue;

    private string textValue;

    public void Loading()
    {
        bar.SetActive(true);
        StartCoroutine(LoadingAsynchrousluy(2));
    }

    IEnumerator LoadingAsynchrousluy(int index)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);


            //for the slider 
            slider.value = progress;

            //for the text
            float value = Mathf.Round(progress * 100);
            Debug.Log(value);
            textValue = value.ToString("f0");
            loadValue.GetComponent<TextMeshProUGUI>().text = "" + textValue + "%";

            yield return null;

        }

    }
}
