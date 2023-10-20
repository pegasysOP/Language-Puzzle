using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] Transform handlePivot;
    [SerializeField] Vector3 handleActivationRotation;
    [SerializeField] float degreesPerSecond = 1f;

    [Space(10)]
    [SerializeReference] private GameObject activatable;
    private IActivatable _activatable;

    private Vector3 defaultHandleRotation;

    private bool isMoving;

    private void Awake()
    {
        IActivatable attempt = activatable.GetComponent<IActivatable>();

        if (attempt == null)
            throw new NotSupportedException($"{name} > Activatable provided does not implement the IInteractable interface");

        _activatable = attempt;

        defaultHandleRotation = handlePivot.localEulerAngles;
    }

    public bool Interact()
    {
        if (!CanInteract())
            return false;

        StartCoroutine(MoveHandle());

        return _activatable.Activate();
    }

    public bool CanInteract()
    {
        if (_activatable == null)
            return false;

        if (isMoving)
            return false;

        return _activatable.CanActivate();
    }

    private IEnumerator MoveHandle()
    {
        isMoving = true;

        Quaternion targetHandleRotation = Quaternion.Euler(defaultHandleRotation);
        // if already at the default position move to the target
        if (Quaternion.Angle(handlePivot.rotation, targetHandleRotation) < 1f)
            targetHandleRotation = Quaternion.Euler(defaultHandleRotation + handleActivationRotation);

        Debug.LogError($"DEFAULT ROTATION = {defaultHandleRotation}");
        Debug.LogError($"TARGET ROTATION = {targetHandleRotation}");

        while (Quaternion.Angle(handlePivot.rotation, targetHandleRotation) > 1f)
        {
            handlePivot.rotation = Quaternion.RotateTowards(handlePivot.rotation, targetHandleRotation, degreesPerSecond * Time.deltaTime);

            Debug.LogWarning($"NEW EULER = {handlePivot.localEulerAngles}");
            yield return null;
        }

        handlePivot.rotation = targetHandleRotation;
        isMoving = false;
    }
}
