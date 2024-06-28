using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimpoint : MonoBehaviour
{
    [SerializeField] GameObject Aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimPoint();
    }
   Vector3 AimPoint()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
        Aim.transform.position = mouseWorldPosition;
        return mouseWorldPosition;
    }
}
