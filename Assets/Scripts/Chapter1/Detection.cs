using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{


    public class Detection : MonoBehaviour
    {


        private RaycastHit hit;
        private float range = 5f;
        public LayerMask detectionLayer;
        public float checkRate = 0.5f;
        public float nextCheck;
        public Transform thisTransform;
        // Start is called before the first frame update
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            DetectItems();
        }

        void SetInitialReferences()
        {
            thisTransform = transform;
            detectionLayer = 1 << 7;
        }

        void DetectItems()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;

                if (Physics.Raycast(thisTransform.position, thisTransform.forward, out hit, range, detectionLayer))
                {
                    Debug.Log(hit.transform.name + ",an item!");
                }
            }
        }
    }

}