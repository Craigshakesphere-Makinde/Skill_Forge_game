using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private float carX;
    [SerializeField] private float carY;
    [SerializeField] private float carZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carX=transform.rotation.eulerAngles.x;
        carY=transform.rotation.eulerAngles.y;
        carZ=transform.rotation.eulerAngles.z;
        box.transform.rotation= Quaternion.Euler(carX-carX, carY, carZ-carZ);

        
    }
}
