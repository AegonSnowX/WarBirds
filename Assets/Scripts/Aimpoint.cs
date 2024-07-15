using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimpoint : MonoBehaviour
{
    [SerializeField] GameObject Aim;
    public bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
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
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoFireZone"))
        {
            Debug.Log("Hitting Zone");
            canFire = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoFireZone"))
        {
            //StartCoroutine("");
            Debug.Log("Leaving Hitting Zone");
            canFire = true;
        }
    }
}
