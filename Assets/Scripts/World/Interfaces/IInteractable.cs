/// <summary>
/// Interface for all objects that can be interacted with
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Triggers this objects interaction
    /// </summary>
    /// <returns>Returns true if interaction executed successfully</returns>
    public bool Interact();

    /// <summary>
    /// Checks if the object can be interacted with
    /// </summary>
    /// <returns>Returns true if the object can be interacted with</returns>
    public bool CanInteract();
}
