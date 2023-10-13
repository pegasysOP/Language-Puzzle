using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2.0f;
    
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameManager.instance.GetPlayer().transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Gets the direction relative to the cameras own forward
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public Vector3 GetRelativeDirection(Vector3 direction)
    {
        return transform.TransformDirection(direction);
    }
}
