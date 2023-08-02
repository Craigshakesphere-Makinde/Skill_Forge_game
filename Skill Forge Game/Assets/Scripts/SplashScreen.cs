using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private GameObject davidScreen;
    [SerializeField] private GameObject skillForgeScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMenu());
        
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(2f);
        davidScreen.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        davidScreen.SetActive(false);
        skillForgeScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
