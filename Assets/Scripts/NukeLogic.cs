using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeLogic : MonoBehaviour
{
    [SerializeField] GameObject NukeExplosion;
    [SerializeField] GameObject WarHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       GameObject nuke= Instantiate(NukeExplosion, WarHead.transform.position, Quaternion.identity);
        Destroy(gameObject);

        ExplosionDestroyer destroyer = nuke.AddComponent<ExplosionDestroyer>();
        destroyer.lifeSecondsLeft = 4;
       
    }
}
