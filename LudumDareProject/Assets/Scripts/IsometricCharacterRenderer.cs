using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IsometricCharacterRenderer : MonoBehaviour
{
    enum Directions
    {
        left,
        down,
        right,
        up
    }

    public static readonly string[] staticDirections = { "Static NW", "Static SW", "Static SE", "Static NE" };
    public static readonly string[] runDirections = { "Run NW", "Run SW", "Run SE", "Run NE" };

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetDirection(string direction, bool moving)
    {
        //use the Run states by default
        string[] directionArray = null;

        //measure the magnitude of the input.
        if(!moving)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
        }

        int dirIndex = Array.IndexOf(Enum.GetNames(typeof(Directions)), direction);
        animator.Play(directionArray[dirIndex]);
    }

    //this function converts a string array to a int (animator hash) array.
    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        //allocate the same array length for our hash array
        int[] hashArray = new int[animationArray.Length];
        //loop through the string array
        for(int i = 0; i < animationArray.Length; i++)
        {
            //do the hash and save it to our hash array
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        //we're done!
        return hashArray;
    }

}