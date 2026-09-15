using UnityEngine;
using System.Collections.Generic;

public class PuzzleLogic : ActivatorBase
{
    [System.Serializable]
    public class PuzzleObject
    {
        public ActivatorBase activator;
        public bool value;

    }
    public List<PuzzleObject> PuzzleObjectsList = new List<PuzzleObject>();

    void Start()
    {
        foreach (var puzzleObject in PuzzleObjectsList)
        {
            puzzleObject.activator.ToActivate.AddListener(ActivatorUpdated);
        }
    }
    void ActivatorUpdated(bool newActive)
    {
        Debug.Log("lever Activated");
        bool correct = CheckPuzzleCorrect();
        _isActivated = correct; //logic
        ActivateObjects(correct); //logic
    }
    bool CheckPuzzleCorrect()

    //comprobar si cada objeto coincide con su equivalente en la otra lista
    {
        foreach (var item in PuzzleObjectsList)
        {
            if (item.activator.IsActivated != item.value)
            {
                return false;
            }
        }

        return true;



    }
}
