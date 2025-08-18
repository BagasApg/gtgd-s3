using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1
{
    public class GrenadeExplosion : MonoBehaviour
    {
        private Collider[] hitColliders;
        public float blastRadius;
        public float explosionPower;

        public LayerMask explosionLayer;

        private float cleanUpTime = 7;
        void OnCollisionEnter(Collision col)
        {
            ExplosionWork(col.contacts[0].point);
            Destroy(gameObject);
        }

        void ExplosionWork(Vector3 explosionPoint)
        {
            hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayer);
            foreach (Collider hitCol in hitColliders)
            {
                if (hitCol.GetComponent<NavMeshAgent>() != null)
                {
                    hitCol.GetComponent<NavMeshAgent>().enabled = false;
                }

                // Debug.Log(hitCol.gameObject.name);
                if (hitCol.GetComponent<Rigidbody>() != null)
                {
                    hitCol.GetComponent<Rigidbody>().isKinematic = false;
                    hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);

                }

                if (hitCol.CompareTag("Enemy"))
                {
                    Destroy(hitCol.gameObject, cleanUpTime);
                }
            }
        }
    }
}
