using UnityEngine;

namespace Scripts_2D_Platformer.Systems
{
    public class TriggerAreaLoad : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameEvents.Current.SavePointLoad();
        }
    }
}
