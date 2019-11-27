using System.Collections.Generic;
using Menu;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unit;

public class KeyBoard : MonoBehaviour
{
    private Command mainCameraScrollingOnRight;
    private Command mainCameraScrollingOnLeft;
    private Command mainCameraScrollingOnUp;
    private Command mainCameraScrollingOnDown;
    private Command stopUnits;
    private Command selectAllUnits;
    private Command mainCameraGoToSelectedUnit;
    private Command pause;
    private Command soundMute;
    private Command soundUnmute;
    private Command preSpellAbility1;
    private Command abandonBuilding;
    private Command cancelBuilding;

    public Button SelectAll;

    void Start()
    {
        mainCameraScrollingOnRight = new MainCameraScrollingOnRight(MainCamera.instance);
        mainCameraScrollingOnLeft = new MainCameraScrollingOnLeft(MainCamera.instance);
        mainCameraScrollingOnUp = new MainCameraScrollingOnUp(MainCamera.instance);
        mainCameraScrollingOnDown = new MainCameraScrollingOnDown(MainCamera.instance);
        stopUnits = new StopUnits();
        selectAllUnits = new SelectAllUnits();
        mainCameraGoToSelectedUnit = new MainCameraGoToSelectedUnit();
        pause = new Pause();
        soundMute = new SoundMute(SoundManagment.instance);
        soundUnmute = new SoundUnmute(SoundManagment.instance);
        preSpellAbility1 = new PreSpellAbility1();
        abandonBuilding = new AbandonBuilding();
        cancelBuilding = new CancelBuilding();
    }
    void Update()
    {
        CamerasHotHeys();
        BuildingsOrdersHotkeys();
        UnitsOrdersHotkeys();
        SystemsHotKeys();
        SelectionHotKeys();
    }

    private void BuildingsOrdersHotkeys()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SelectionManager.instance.IsCurrentlySelectedBuildingUnderConstruction)
                cancelBuilding.Execute();
        }
    }

    private void CamerasHotHeys()
    {
        if (Input.GetKey(KeyCode.RightArrow) && MainCamera.instance.IsThisTheRightBorderOfTheMap && !MouseManager.instance.IsCursorLocatedOnRightBorderOfTheScreen)
            mainCameraScrollingOnRight.Execute();
        if (Input.GetKey(KeyCode.LeftArrow) && MainCamera.instance.IsThisTheLeftBorderOfTheMap && !MouseManager.instance.IsCursorLocatedOnLeftBorderOfTheScreen)
            mainCameraScrollingOnLeft.Execute();
        if (Input.GetKey(KeyCode.UpArrow) && MainCamera.instance.IsThisTheTopBorderOfTheMap && !MouseManager.instance.IsCursorLocatedOnBottomBorderOfTheScreen)
            mainCameraScrollingOnUp.Execute();
        if (Input.GetKey(KeyCode.DownArrow) && MainCamera.instance.IsThisTheBottomBorderOfTheMap && !MouseManager.instance.IsCursorLocatedOnTopBorderOfTheScreen)
            mainCameraScrollingOnDown.Execute();
        if (Input.GetKey(KeyCode.Space))
            mainCameraGoToSelectedUnit.Execute();
    }
    private void UnitsOrdersHotkeys()
    {
        if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.LeftControl) && SelectionManager.instance.IsSelectedAnyUnit)
            stopUnits.Execute();
        if (Input.GetKeyDown(KeyCode.R))
            preSpellAbility1.Execute();
        if (Input.GetKeyUp(KeyCode.Escape))
            abandonBuilding.Execute();
    }
    private void SystemsHotKeys()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
        {
            if (SoundManagment.instance.IsMuted)
                soundUnmute.Execute();
            else
                soundMute.Execute();
        }
        if (Input.GetKeyDown(KeyCode.F10))
            pause.Execute();
    }
    private void SelectionHotKeys()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (UnitManager.instance.combatUnits.Count > 0)
            {
                selectAllUnits.Execute();
                SelectAll.Select();
            }
        }
    }
}