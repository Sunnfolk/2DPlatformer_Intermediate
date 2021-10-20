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
            PlayerPrefs.SetFloat("transform.pos.x", transform.position.x);
            PlayerPrefs.SetFloat("transform.pos.y", transform.position.y);
        }

        private void OnLoad()
        {
            var posX = PlayerPrefs.GetFloat("transform.pos.x");
            var posY = PlayerPrefs.GetFloat("transform.pos.y");
            transform.position = new Vector2(posX, posY);
        }

        private void OnDestroy()
        {
            GameEvents.current.ONSavePointCollisionEnter -= OnSave;
            GameEvents.current.OnSavePointCollisionLoad -= OnLoad;
        }
    }
}