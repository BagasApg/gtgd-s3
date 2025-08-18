using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class Trigger : MonoBehaviour
    {
        private WalkThroughWall walkThroughWallScript;
        private GameManager_EventMaster eventMaster_Script;
        void Start()
        {
            SetInitinialReferences();
        }

        void OnTriggerEnter(Collider other)
        {
            eventMaster_Script.CallSpawnEnemy();

            Destroy(gameObject);
        }

        void SetInitinialReferences()
        {
            eventMaster_Script = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }
    }
}
