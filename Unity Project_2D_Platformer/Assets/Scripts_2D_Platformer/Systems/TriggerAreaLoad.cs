using Scripts_2D_Platformer.Systems;
using UnityEngine;

public class TriggerAreaLoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.current.SavePointLoad();
    }
}
