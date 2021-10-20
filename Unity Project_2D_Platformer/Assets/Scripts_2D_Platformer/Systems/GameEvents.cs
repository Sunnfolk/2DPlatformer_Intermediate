using System;
using UnityEngine;

namespace Scripts_2D_Platformer.Systems
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents current;
        private void Awake()
        {
            current = this;
        }

        public event Action ONSavePointCollisionEnter;
        public void SavePointCollision()
        {
            if (ONSavePointCollisionEnter != null)
            {
                ONSavePointCollisionEnter();
            }
        }

        public event Action OnSavePointCollisionLoad;
        public void SavePointLoad()
        {
            if (OnSavePointCollisionLoad != null)
            {
                OnSavePointCollisionLoad();
            }
        }
    }
}
