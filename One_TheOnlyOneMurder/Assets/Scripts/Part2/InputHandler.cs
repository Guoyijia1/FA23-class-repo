using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.
using TMPro;

public class InputHandler : MonoBehaviour
{
    //saltyfamily
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;
    public TMP_InputField inputField5;
    public TMP_InputField inputField6;
    public TMP_InputField inputField7;
    public TMP_InputField inputField8;
    public TMP_InputField inputField9;
    public TMP_InputField inputField10;
    public TMP_InputField inputField11;
    

    public Canvas targetCanvas; // Reference to the Canvas you want to activate

    private void Update()
    {
        // Check if all input fields contain the correct letters 'a', 'b', and 'c'
        if (IsCorrectInput(inputField1, 's')
            && IsCorrectInput(inputField2, 'a')
            && IsCorrectInput(inputField3, 'l')
            && IsCorrectInput(inputField4, 't')
            && IsCorrectInput(inputField5, 'y')
            && IsCorrectInput(inputField6, 'f')
            && IsCorrectInput(inputField7, 'a')
            && IsCorrectInput(inputField8, 'm')
            && IsCorrectInput(inputField9, 'i')
            && IsCorrectInput(inputField10, 'l')
            && IsCorrectInput(inputField11, 'y')



            )
        {
            targetCanvas.gameObject.SetActive(true); // Activate the Canvas
        }
        else
        {
            targetCanvas.gameObject.SetActive(false); // Deactivate the Canvas
        }
    }

    private bool IsCorrectInput(TMP_InputField inputField, char expectedChar)
    {
        if (inputField != null && inputField.text.Length == 1)
        {
            char inputChar = char.ToLower(inputField.text[0]);
            expectedChar = char.ToLower(expectedChar);
            return inputChar == expectedChar;
        }
        return false;
    }
}
