using System;
using System.Collections;
using System.Collections.Generic;
using Scripts_2D_Platformer.Systems;
using UnityEngine;

public class TriggerAreaSave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.current.SavePointCollision();
    }
}
