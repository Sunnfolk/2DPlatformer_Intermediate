using Scripts_2D_Platformer.Systems;
using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class PlayerSaveData : MonoBehaviour
    {
        private void Start()
        {
            GameEvents.current.ONSavePointCollisionEnter += OnSave;
            GameEvents.current.OnSavePointCollisionLoad += OnLoad;
        }

        private void OnSave()
        {
            var position = transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", position.x);
            PlayerPrefs.SetFloat("PlayerPosY", position.y);
        }

        private void OnLoad()
        {
            var posX = PlayerPrefs.GetFloat("PlayerPosX");
            var posY = PlayerPrefs.GetFloat("PlayerPosY");
            transform.position = new Vector2(posX, posY);
        }

        private void OnDestroy()
        {
            GameEvents.current.ONSavePointCollisionEnter -= OnSave;
            GameEvents.current.OnSavePointCollisionLoad -= OnLoad;
        }
    }
}