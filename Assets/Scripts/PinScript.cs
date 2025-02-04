using TMPro;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public int number;
    public TextMeshProUGUI numberText;

    public void ChangePin(bool increase)
    {
        if (increase)
        {
            number++;
            number = number % 10;
            numberText.text = number.ToString();
            return;
        }

        number--;
        number += 10;
        number %= 10;
        numberText.text = number.ToString();
    }
}
