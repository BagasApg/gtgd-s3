using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{


    public class Spawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public int numberOfEnemies;
        private float spawnRadius = 5;
        private Vector3 spawnPosition;
        private GameManager_EventMaster eventMaster_Script;

        void OnEnable()
        {
            SetInitinialReferences();
            eventMaster_Script.spawnEnemy += SpawnObject;
        }

        void OnDisable()
        {
            eventMaster_Script.spawnEnemy -= SpawnObject;
        }

        void SetInitinialReferences()
        {
            eventMaster_Script = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void SpawnObject()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                spawnPosition = transform.position + (Random.insideUnitSphere * spawnRadius);

                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }

}