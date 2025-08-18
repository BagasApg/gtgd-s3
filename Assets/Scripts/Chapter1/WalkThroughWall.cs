using System.Collections;
using System.Collections.Generic;
using Chapter1;
using UnityEngine;

public class WalkThroughWall : MonoBehaviour
{
    private Color paleGreen = new Color(0.5f, 1, 0.5f, 1);
    private GameManager_EventMaster eventMaster_Script;
    void OnEnable()
    {
        SetInitialReferences();
        eventMaster_Script.spawnEnemy += SetLayerToNotSolid;
    }

    void OnDisable()
    {

        eventMaster_Script.spawnEnemy -= SetLayerToNotSolid;
    }

    void SetInitialReferences()
    {
        eventMaster_Script = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
    }

    public void SetLayerToNotSolid()
    {
        gameObject.layer = LayerMask.NameToLayer("Not Solid");
        GetComponent<Renderer>().material.SetColor("_Color", paleGreen);
    }

}
