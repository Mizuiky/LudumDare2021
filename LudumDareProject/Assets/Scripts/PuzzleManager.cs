using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private Puzzle[] puzzles;

    [SerializeField]
    private Puzzle[] puzzleSolution;

    private Puzzle currentPuzzle;

    void Start()
    {
        
    }

 
    void Update()
    {
        if(currentPuzzle.isResolved)
        {
            //chamar audio de puzzle resolvido
            //chamar proximo puzzle ou tela de score
        }
    }
}
