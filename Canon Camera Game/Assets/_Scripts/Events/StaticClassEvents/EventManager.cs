using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for storing events in one place.
/// This event system is less resource intensive than a scriptable object event system that uses UnityEvents.
/// Con: not as good for team collaboration, because of potential conflicts from working in this class.
/// </summary>
public static class EventManager
{
    public static Event OnAimCamera { get; } = new();
    public static Event OnLowerCamera { get; } = new();
    public static Event OnTakePhoto { get; } = new();
    public static Event<bool> OnChangeLens { get; } = new(); // bool: ScrollUp
    public static Event<Objective> OnCompletedObjective { get; } = new();
    public static Event<bool> OnObjectivesListOpen { get; } = new();
}
