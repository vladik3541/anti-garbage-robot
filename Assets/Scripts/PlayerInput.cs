using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Action<bool> OnUseLaser;
    public Action OnSelect;
    public Action OnUseBomb;
    public Action<bool> OnUsevacuumCleaner;

    private Main inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new Main();
    }
    private void OnEnable()
    {
        inputActions.Enable();
        //UseLaser
        inputActions.Player.LaserKeyboard.performed += UseLaser;
        inputActions.Player.LaserGamePad.performed += UseLaser;
        inputActions.Player.LaserKeyboard.canceled += StopUseLaser;
        inputActions.Player.LaserGamePad.canceled += StopUseLaser;
        //Select
        inputActions.Player.SelectKeyboard.performed += Select;
        inputActions.Player.SelectGamepad.performed += Select;
        //UseBomb
        inputActions.Player.BombKeyboard.performed += UseBomb;
        inputActions.Player.BombGamepad.performed += UseBomb;
        //useVacuumCleaner
        inputActions.Player.UseVacuumKeyoard.performed += UseVacuum;
        inputActions.Player.UseVacuumGamePad.performed += UseVacuum;
        //stopVacuum
        inputActions.Player.UseVacuumKeyoard.canceled += StopUseVacuum;
        inputActions.Player.UseVacuumGamePad.canceled += StopUseVacuum;
    }
    private void OnDisable()
    {

        //UseLaser
        inputActions.Player.LaserKeyboard.performed -= UseLaser;
        inputActions.Player.LaserGamePad.performed -= UseLaser;
        inputActions.Player.LaserKeyboard.canceled -= StopUseLaser;
        inputActions.Player.LaserGamePad.canceled -= StopUseLaser;
        //Select
        inputActions.Player.SelectKeyboard.performed -= Select;
        inputActions.Player.SelectGamepad.performed -= Select;
        //UseBomb
        inputActions.Player.BombKeyboard.performed -= UseBomb;
        inputActions.Player.BombGamepad.performed -= UseBomb;
        //useVacuumCleaner
        inputActions.Player.UseVacuumKeyoard.performed -= UseVacuum;
        inputActions.Player.UseVacuumGamePad.performed -= UseVacuum;
        //stopVacuum
        inputActions.Player.UseVacuumKeyoard.canceled -= StopUseVacuum;
        inputActions.Player.UseVacuumGamePad.canceled -= StopUseVacuum;


        OnUseLaser = null;
        OnSelect = null;
        OnUseBomb = null;
        inputActions.Disable();
        
    }
    private void UseLaser(InputAction.CallbackContext value)
    {
        OnUseLaser?.Invoke(true);
    }
    private void StopUseLaser(InputAction.CallbackContext value)
    {
        OnUseLaser?.Invoke(false);
    }

    private void Select(InputAction.CallbackContext value)
    {
        OnSelect?.Invoke();
    }

    private void UseBomb(InputAction.CallbackContext value)
    {
        OnUseBomb?.Invoke();
    }
    private void UseVacuum(InputAction.CallbackContext value)
    {
        OnUsevacuumCleaner?.Invoke(true);
    }
    private void StopUseVacuum(InputAction.CallbackContext value)
    {
        OnUsevacuumCleaner?.Invoke(false);
    }


}
