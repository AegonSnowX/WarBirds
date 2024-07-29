using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirdropLogic : MonoBehaviour
{
    [SerializeField] GameObject Parachute;
    
    [SerializeField] GameObject Artillary;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if((Parachute != null)&&(transform.position.y<=-2.1))
        {
            DestroyParachute();
        }
      
    }
    public void DestroyParachute()
    {
        Parachute.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
        Vector3 position = new Vector3(-7.62f, -2.28f, 0);
        Instantiate(Artillary, position, Quaternion.identity);
    }


}
