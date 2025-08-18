using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{

    public class GameManager_EventMaster : MonoBehaviour
    {

        public delegate void GeneralEvent();
        public event GeneralEvent spawnEnemy;

        public void CallSpawnEnemy()
        {
            if (spawnEnemy != null)
            {
                spawnEnemy();
            }
        }
    }

}