using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, IActivatable
{
    [SerializeField] private Vector3 activationTranslation;
    [SerializeField] private float moveSpeed = 1f;

    private Vector3 defaultPosition;

    private bool isMoving;

    private void Awake()
    {
        defaultPosition = transform.position;
    }

    public bool Activate()
    {
        if (isMoving)
            return false;

        StartCoroutine(MoveDoor());
        
        return true;
    }

    public bool CanActivate()
    {
        return !isMoving;
    }

    private IEnumerator MoveDoor()
    {
        isMoving = true;

        Vector3 targetPosition = defaultPosition;
        // if already at the default position move to the target
        if (Vector3.Distance(transform.position, defaultPosition) < 0.001f)
            targetPosition += activationTranslation;

        while (Vector3.Distance(transform.position, targetPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null;
        }

        isMoving = false;
    }
}
