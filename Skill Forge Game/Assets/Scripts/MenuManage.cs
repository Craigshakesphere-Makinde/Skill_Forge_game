using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManage : MonoBehaviour
{
    [SerializeField] private GameObject creditBox;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject PauseMenu;
    
    public void Pause()
    {

        StartCoroutine(Pausing());
    }

    public void Resume()
    {
        StartCoroutine(Resuming());
    }

    IEnumerator Pausing()
    {
        PauseMenu.SetActive(true);
        yield return new WaitForSeconds(.5f);


        Time.timeScale = 0f;


    }

    IEnumerator Resuming()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        yield return new WaitForSeconds(1);

        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);

    }

    public void ShowCredit()
    {
        creditBox.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void DeactivateCredit()
    {
        creditBox.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void EndGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadmainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
