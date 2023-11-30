using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private static InputManager _controls;

    public static void init(BallController ballController)
    {
        _controls = new InputManager();

        _controls.Game.Movement.performed += ctx =>
        {
            ballController.SetMovementDirection(ctx.ReadValue<Vector3>());
        };
    }

    public static void GameMode()
    {
        _controls.Game.Enable();
    }


}
