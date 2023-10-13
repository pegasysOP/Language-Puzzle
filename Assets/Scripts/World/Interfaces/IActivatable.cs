using System;
/// <summary>
/// Interface for all objects that can be activated
/// </summary>
public interface IActivatable
{
    /// <summary>
    /// Activates this object
    /// </summary>
    /// <returns>Returns true if activated successfully</returns>
    public bool Activate();

    /// <summary>
    /// Checks if the object can be activated
    /// </summary>
    /// <returns>Returns true if the object can be activated</returns>
    public bool CanActivate();
}
