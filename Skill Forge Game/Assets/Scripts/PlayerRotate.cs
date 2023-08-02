using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private float horizontal, vertical;
    [SerializeField] private float rotSpeed=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        transform.Rotate((horizontal * rotSpeed * Vector3.up) * Time.deltaTime, Space.World);
        if (transform.rotation.eulerAngles.x < -40 )
        {
            
            transform.Rotate(vertical * rotSpeed * -Vector3.left * Time.deltaTime, Space.Self);
        }
        else if(transform.rotation.eulerAngles.x > 20)
        {
            
            transform.Rotate(vertical * rotSpeed * Vector3.left * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(vertical * rotSpeed * Vector3.left * Time.deltaTime, Space.Self);
        }
        

    }
}
