using UnityEngine;
using System.Collections.Generic;

public class PuzzleLogic: ActivatorBase
{
    [System.Serializable]
    public class PuzzleObject
    {
        public ActivatorBase Object;
        public bool value;

    }
    public List<PuzzleObject> PuzzleObjectsList = new List<PuzzleObject>();


    void Update()
    // me falta hacer que esto solo se ejecute cuando el jugador interactua con el puzzle, no en cada frame
    {
        Activate();
    }

    void OnActivateObject()
    //se llama a esta funcion cuando el jugador interactua con cualquiera de las aprtes del puzzle
    // entiendo que los objetos emiten algo cuando se activan pero no lo encuentro
    //mi solucion sería comprobar en el update si alguno de los objetos de la lista ha cambiado de estado cuando
    //y si es así llamar a la funcion Activate() que comprueba si el puzzle está resuelto
    {
        foreach (var puzzleObject in PuzzleObjectsList)
        {   

        }
    }
    bool CheckActiveObjects()

    //comprobar si cada objeto coincide con su equivalente en la otra lista
    {
        for (int i = 1; i < PuzzleObjectsList.Count; i++)
        {
            if (PuzzleObjectsList[i].Object.IsActivated != PuzzleObjectsList[i].value)
            {
                return false;
            }
        }
        Debug.Log("puzzle: solucionado");
        return true;
        
    }
    private void Activate()
    {
        _isActivated = CheckActiveObjects(); //logic
        ActivateObjects(_isActivated); //logic
    }


}
