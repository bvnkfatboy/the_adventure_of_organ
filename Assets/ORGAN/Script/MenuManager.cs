using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MenuManager : MonoBehaviour
{
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;

    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // Debug.Log("Test");
            SceneManager.LoadScene("Charecter");
        }
        else if (SelectedButton == 2)
        {
            Application.Quit();
        }
    }
    private void OnButtonUp()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves up one button
        if (SelectedButton > 1)
        {
            SelectedButton -= 1;
        }
        return;
    }
    private void OnButtonDown()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
        if (SelectedButton < NumberOfButtons)
        {
            SelectedButton += 1;
        }
        return;
    }
}
