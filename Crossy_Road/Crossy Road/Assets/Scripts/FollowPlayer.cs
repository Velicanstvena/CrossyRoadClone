using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float duration;

    void Update()
    {
        if (playerPos != null)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, duration);
        }
    }
}
