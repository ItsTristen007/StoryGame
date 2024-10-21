using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager 
{

    private static GameControls _gameControls;


    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        

        _gameControls.InGame.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };
        
        _gameControls.InGame.Jump.started += hi =>
        {
            myPlayer.jump();
        };


        _gameControls.InGame.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };
        
    }
    


    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();

    }


    public static void SetUIControls()
    {
        _gameControls.InGame.Disable();
    }
}