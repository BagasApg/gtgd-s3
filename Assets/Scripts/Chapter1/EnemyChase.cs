using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1
{


    public class EnemyChase : MonoBehaviour
    {
        public LayerMask detectionLayer;
        private Transform enemyTransform;
        private NavMeshAgent enemyNavMeshAgent;
        private Collider[] hitColliders;

        private float checkRate;
        private float nextCheck;
        private float detectionRadius = 50;

        void SetInitinialReferences()
        {
            enemyTransform = transform;
            enemyNavMeshAgent = GetComponent<NavMeshAgent>();
            checkRate = Random.Range(0.8f, 1.2f);
        }

        void CheckIfPlayerInRange()
        {
            if (Time.time > nextCheck && enemyNavMeshAgent.enabled)
            {
                nextCheck = Time.time + checkRate;

                hitColliders = Physics.OverlapSphere(enemyTransform.position, detectionRadius, detectionLayer);

                if (hitColliders.Length > 0)
                {
                    enemyNavMeshAgent.SetDestination(hitColliders[0].transform.position);
                }

            }
        }

        // Start is called before the first frame update
        void Start()
        {
            SetInitinialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfPlayerInRange();
        }
    }

}