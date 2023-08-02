using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionComplete : MonoBehaviour
{
    [SerializeField] private GameObject missionComplete;
    [SerializeField] private GameObject deactivateUi;
    [SerializeField] private TextMeshProUGUI totalScore;
    public ScoreManager scorer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Completed());
        }
        
        
    }

    IEnumerator Completed()
    {
        missionComplete.SetActive(true);
        deactivateUi.SetActive(false);
        totalScore.GetComponent<TextMeshProUGUI>().text= scorer.score.ToString();
        
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;

    }
}
