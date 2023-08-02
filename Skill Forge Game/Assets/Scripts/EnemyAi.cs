using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float radius;



    void Update()
    {
        // we find the transform of an object which possess the Component CARCONTROLLER 
        //then check to see if the distance from the player to the enemy is les than a certain value, if it is, we face the player
        target = FindObjectOfType<PlayerDamage>().transform;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= radius)
        {
            FacePlayer();
            //transform.LookAt(target.position);

        }
    }
    private void FacePlayer()
    {
        // we find a vector 3 value which is the normalized value of the player and enemy
        // then we define  a new rotation which is where the enemy will face
        Vector3 direct = (target.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(new Vector3(direct.x,direct.y, direct.z));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {

        // this is just indicate boundaries
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
