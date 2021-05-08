// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class ChatManager : MonoBehaviour
{
    private static ChatManager instance; // an instance of the class to encapsulate private methods
    
    private List<ChatManagerInstance> chatManagerInstances; // list of instances to handle multiple instances

    private void Awake() 
    {
        // method on init of class
        instance = this;
        chatManagerInstances = new List<ChatManagerInstance>();
    }

    private void Update() 
    {
        // update each cmi which is in an i with each update cycle
        for (int i = 0; i < chatManagerInstances.Count; i++) {
            bool endInstance = chatManagerInstances[i].Update();
            if (endInstance) {
                // if already finished printing, remove this instance from list
                chatManagerInstances.RemoveAt(i);
                i--;
            }
        }
    }

    public static ChatManagerInstance AddWriterStatic(TMP_Text uiText, string textToWrite, float timePerChar, bool invisChars, bool removeWriter, Action isComplete, bool bletchleyPark) 
    {
        // static exposed function
        if (removeWriter) {
            // if it's the same as what has already been printed, remove
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerChar, invisChars, isComplete, bletchleyPark);
    }

    public static void RemoveWriterStatic(TMP_Text uiText) 
    {
        // static exposed function
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(TMP_Text uiText) 
    {
        // remove if already done writing
        for (int i = 0; i < chatManagerInstances.Count; i++) {
            if (chatManagerInstances[i].GetText() == uiText) {
                chatManagerInstances.RemoveAt(i);
                i--; 
            }
        }
    }

    private ChatManagerInstance AddWriter(TMP_Text uiText, string textToWrite, float timePerChar, bool invisChars, Action isComplete, bool bletchleyPark) 
    {
        // initialize
        ChatManagerInstance chatManagerInstance = new ChatManagerInstance(uiText, textToWrite, timePerChar, invisChars, isComplete, bletchleyPark);
        chatManagerInstances.Add(chatManagerInstance);
        return chatManagerInstance;
    }

    public class ChatManagerInstance 
    {

        private TMP_Text uiText; // full text to type
        private string textToWrite; // remaining text to type
        private int charIndex; // index of current text 
        private float timePerChar; // time taken for each char to be written
        private float timer; // timing time 
        private bool invisChars; // remaining text that has yet to be typed, which is currently invis
        private Action isComplete; // if action has been completed
        private bool bletchleyPark; // if the text is to do the funky bletchley park thing

        public char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=[{]}:;>.<,?/~`".ToArray(); // list of char for Bletchley Park

        public ChatManagerInstance(TMP_Text uiText, string textToWrite, float timePerChar, bool invisChars, Action isComplete, bool bletchleyPark) 
        {
            // initialize
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerChar = timePerChar;
            this.invisChars = invisChars;
            this.isComplete = isComplete;
            this.bletchleyPark = bletchleyPark;
            charIndex = 0;
        }

        public bool Update() 
        {
            timer -= Time.deltaTime;
            while (timer <= 0f) { // display next char
                timer += timePerChar;
                charIndex++;
                string text = textToWrite.Substring(0, charIndex);
                if (invisChars) 
                {
                    // makes rest of yet to be rendered text invis so all text stays static
                    text += "<color=#00000000>" + textToWrite.Substring(charIndex) + "</color>";
                }
                if (bletchleyPark) {
                    for (int i = 0; i < textToWrite.Length-charIndex; i++) {
                        if (textToWrite.Substring(charIndex+i, 1) == " ") {
                            text += " ";
                        } else {
                            text += letters[UnityEngine.Random.Range(0, letters.Length)];                            
                        }
                    }
                }
                text = "<mspace=1>" + text + "</mspace>";
                uiText.text = text;
                if (charIndex >= textToWrite.Length) 
                {
                    // entire string displayed
                    if (isComplete != null) isComplete();
                    return true;                    
                }

            }
            return false;
        }

        public TMP_Text GetText() 
        {
            // getter for text in class
            return uiText;
        }

        public bool IsActive() 
        {
            // check if speech bubble is still typing
            return (charIndex < textToWrite.Length);
        }

        public void InstantWrite() 
        {
            // instantly write everything, called by click
            uiText.text = textToWrite;
            charIndex = textToWrite.Length;
            if (isComplete != null) isComplete();
            ChatManager.RemoveWriterStatic(uiText);
        }
    }        
}
