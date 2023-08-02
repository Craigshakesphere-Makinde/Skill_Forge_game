using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public CarController CarController;
    [SerializeField] private TextMeshProUGUI healthBox;
    [SerializeField] private float MaxHealth;
    private float currentHealth;

    [SerializeField] private GameObject explosion;

    public HealthBar healthbar;

    [SerializeField] private GameObject gameOver;

    [SerializeField] private GameObject UI;


    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(currentHealth);
    }
    private void Update()
    {
        healthBox.GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();
    }



    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        
        healthbar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {


            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 3f);
            Die();


        }
    }

    private void Die()
    {
        gameOver.SetActive(true);
        UI.SetActive(false);
        CarController.enabled= false;
        FindObjectOfType<PlayerRotate>().enabled= false;
        Time.timeScale = 0f;
        Debug.Log("Player Is Dead");

    }

}
/*

 */
