using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateReset : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelWinArray_SO levelWinArray_SO;
    private List<Message_SO> message_SOs = new List<Message_SO>();
    public Message_SO tut1;
    public Message_SO lvl2;
    public Message_SO lvl3;
    public Message_SO tut4;
    public Message_SO lvl5;
    public Message_SO lvl6;
    public Message_SO lvl7;
    public Message_SO lvl8;
    public Message_SO lvl9;

    private void Start()
    {
        message_SOs.Add(tut1);
        message_SOs.Add(lvl2);
        message_SOs.Add(lvl3);
        message_SOs.Add(tut4);
        message_SOs.Add(lvl5);
        message_SOs.Add(lvl6);
        message_SOs.Add(lvl7);
        message_SOs.Add(lvl8);
        message_SOs.Add(lvl9);

        //ResetGameState();
    }

    public void ResetGameState()
    {
        foreach (Message_SO message_SO in message_SOs)
        {
            Debug.Log("hell");
            message_SO.Decode_Attempt = "";
        }
        levelWinArray_SO.ResetLevels();

        
    }


}
