using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    //[SerializeField] private TextMeshProUGUI healthBox;
    [SerializeField] private float MaxHealth;
    private float currentHealth;

    [SerializeField] private GameObject explosion;

    public EnemyHealth healthbar;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(currentHealth);
    }



    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {


            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Die();


        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<ScoreManager>().IncreaseScore();
        
        Debug.Log("Enemy Is Dead");

    }

}
/*

 */
