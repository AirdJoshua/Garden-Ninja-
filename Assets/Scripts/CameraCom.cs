using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCom : MonoBehaviour
{
   [SerializeField] private Transform player;

    
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
        
    }
}
