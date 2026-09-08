using UnityEngine;
using System.Collections.Generic;

public class PuzzleLogic: ActivatorBase
{
    public List<ActivatorBase> ActivatorObjectsList = new List<ActivatorBase>();
    public List<bool> PuzzleValues = new List<bool>();

    void Awake() {
        CheckListsCounts();
    }

    void Update() 
    {
        CheckActiveObjects();
    }
    void CheckActiveObjects()
        //comprobar si cada objeto coincide con su equivalente en la otra lista
    {
        for (int i = 1; i < ActivatorObjectsList.Count; i++)
        {
            if (ActivatorObjectsList[i].IsActivated != PuzzleValues[i]) 
            {
                break;
            }
        }
         Activate();

    }
    private void Activate()
    {
        _isActivated = !_isActivated; //logic
        ActivateObjects(_isActivated); //logic
    }

    void CheckListsCounts() {
        if (ActivatorObjectsList.Count != PuzzleValues.Count)
            Debug.LogError("[PuzzleLogic] Lists Counts are different .");
    }

}
