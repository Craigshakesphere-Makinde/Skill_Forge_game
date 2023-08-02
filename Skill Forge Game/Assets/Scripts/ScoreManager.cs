using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreBox;
    public int score;
    [SerializeField] private int value = 10;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        scoreBox.GetComponent<TextMeshProUGUI>().text=score.ToString(); 

    }
    public void IncreaseScore()
    {
        score += value;
    }
}
