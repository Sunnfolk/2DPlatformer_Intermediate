using System;
using Scripts_2D_Platformer.Systems;
using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class PlayerSaveData : MonoBehaviour
    {
        private Transform _collisionObject;
        
        private void Start()
        {
            GameEvents.Current.ONSavePointCollisionEnter += OnSave;
            GameEvents.Current.OnSavePointCollisionLoad += OnLoad;
        }

        private void OnSave()
        {
            if (_collisionObject == null)
            {
                print("Player Transform");
                var position = transform.position;
                PlayerPrefs.SetFloat("PlayerPosX", position.x);
                PlayerPrefs.SetFloat("PlayerPosY", position.y);
            }
            else
            {
                print("Object Transform");
                var position = _collisionObject.position;
                PlayerPrefs.SetFloat("PlayerPosX", position.x);
                PlayerPrefs.SetFloat("PlayerPosY", position.y);
            }
            
        }

        private void OnLoad()
        {
            var posX = PlayerPrefs.GetFloat("PlayerPosX");
            var posY = PlayerPrefs.GetFloat("PlayerPosY");
            transform.position = new Vector2(posX, posY);
        }

        private void OnDestroy()
        {
            GameEvents.Current.ONSavePointCollisionEnter -= OnSave;
            GameEvents.Current.OnSavePointCollisionLoad -= OnLoad;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("CheckPoint"))
            {
                _collisionObject = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _collisionObject = null;
        }
    }
}