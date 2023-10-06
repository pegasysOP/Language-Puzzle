using System;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeReference] private GameObject activatable;
    private IActivatable _activatable;

    private void Awake()
    {
        IActivatable attempt = activatable.GetComponent<IActivatable>(); 

        if (attempt == null)
            throw new NotSupportedException($"{name} > Activatable provided does not implement the IInteractable interface");

        _activatable = attempt;
    }

    public bool Interact()
    {
        if (!CanInteract()) 
            return false;

        // can do button animation here

        return _activatable.Activate();
    }

    public bool CanInteract()
    {
        if (_activatable == null)
            return false;

        return _activatable.CanActivate();
    }
}