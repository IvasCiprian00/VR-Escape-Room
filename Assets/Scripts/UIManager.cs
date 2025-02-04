using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int correctCode;
    public List<PinScript> pinList = new List<PinScript>();

    public void CheckCode()
    {
        int generatedCode = 0;

        foreach(PinScript pin in pinList)
        {
            generatedCode = generatedCode * 10 + pin.number;
        }

        if(generatedCode == correctCode)
        {
            Debug.Log("You guessed it right");
        }
    }
}
