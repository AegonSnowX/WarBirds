using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public HitDetection engineTrigger;
    public HitDetection middleFrontTrigger;
    public HitDetection middleBackTrigger;
    public HitDetection backTrigger;

    public CarPartDamageHandler engineHandler;
    public CarPartDamageHandler middlefrontHandler;
    public CarPartDamageHandler middlebackHandler;
    public CarPartDamageHandler backHandler;
    private void Start()
    {
        engineTrigger.parentDamageHandler = this;
        middleFrontTrigger.parentDamageHandler = this;
        middleBackTrigger.parentDamageHandler = this;
        backTrigger.parentDamageHandler = this;
    }

    public void OnTriggerActivated(GameObject triggerObject, Collider2D collision)
    {
        if (triggerObject.name == "EngineCollider")
        {
            //HealthManager.Instance.DecreaseHealth(5);
            engineHandler.DecreaseHealth(5);
        }
        if (triggerObject.name == "MiddlefrontCollider")
        {
            //HealthManager.Instance.DecreaseHealth(5);
            middlefrontHandler.DecreaseHealth(5);

        }
        if (triggerObject.name == "MiddleBackCollider")
        {
            //HealthManager.Instance.DecreaseHealth(5);
            middlebackHandler.DecreaseHealth(5);

        }
        if (triggerObject.name == "BackCollider")
        {
            //HealthManager.Instance.DecreaseHealth(5);
            backHandler.DecreaseHealth(5);

        }
    }

}
