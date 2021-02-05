using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static void Log(string messageToLog)
    {
        Debug.Log(messageToLog);
    }

    public static bool IsKeyPressed(KeyCode keycode)
    {
        if (Input.GetKeyDown(keycode))
        {
            return true;
        }
        return false;
    }

    public static void ASSERT_STRING(string stringObject)
    {
        if(stringObject == null)
        {
            Debug.Log("NULL STRING!");
        }
    }

}
