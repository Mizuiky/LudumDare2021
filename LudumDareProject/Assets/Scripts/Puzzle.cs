using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] puzzleBoard;

    [HideInInspector]
    public bool isResolved = false;

    // Start is called before the first frame update
    void Start()
    {
        this.isResolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isResolved)
        {

        }
    }

    public void resetPuzzle()
    {

    }
    public void checkPuzzle()
    {

    }
}
