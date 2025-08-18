using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class Shoot : MonoBehaviour
    {
        private float fireRate = 0.3f;
        private float nextFire;
        private RaycastHit hit;
        private float range = 300f;

        // Start is called before the first frame update
        void Start() { }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        void CheckForInput()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                Debug.DrawRay(transform.TransformPoint(0, 0, 1), transform.forward, Color.red, 5f);
                if (
                    Physics.Raycast(
                        transform.TransformPoint(0, 0, 1),
                        transform.forward,
                        out hit,
                        range
                    )
                )
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        Debug.Log("Enemy " + hit.transform.name);
                    }
                    else
                    {
                        Debug.Log("Not an enemy!");
                    }
                }
                nextFire = Time.time + fireRate;
                // Debug.Log("klik");
            }
        }
    }
}
