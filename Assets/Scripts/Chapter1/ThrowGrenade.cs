using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenade_prefabs;
    private Transform thisTransform;

    public float propulsionForce = 30f;

    void Start()
    {
        SetInitialReferences();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnGrenade();
        }
    }

    void SetInitialReferences()
    {
        thisTransform = transform;
    }

    void SpawnGrenade()
    {
        GameObject gObj = (GameObject)Instantiate(
            grenade_prefabs,
            thisTransform.TransformPoint(0, 0, 0.5f),
            thisTransform.rotation
        );
        gObj.GetComponent<Rigidbody>()
            .AddForce(thisTransform.forward * propulsionForce, ForceMode.Impulse);
        Destroy(gObj, 13);
    }
}
