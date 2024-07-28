using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirdropLogic : MonoBehaviour
{
    [SerializeField] GameObject Parachute;
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
}
