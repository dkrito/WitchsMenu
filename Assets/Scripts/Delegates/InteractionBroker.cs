using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class InteractionBroker
{
    public static Action<Vector3, Vector3> PanHandle;

    public static Action<bool> CameraMovementHandle;

    public static void NotifyPanListeners(Vector3 location, Vector3 targetToLookAt)
    {
        if (PanHandle != null)
        {
            PanHandle(location, targetToLookAt);
        }
    }

    public static void NotifyCameraMovement(bool state)
    {
        if (CameraMovementHandle != null)
        {
            CameraMovementHandle(state);
        }
    }
}
