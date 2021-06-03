using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("你被炸了");
    }
}
