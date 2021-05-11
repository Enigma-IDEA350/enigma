using System.Collections.Generic;
using UnityEngine;

public class ListsOfMessages
{
    string[] preArrowTutorial = new string[] {
        "Welcome to your computer!",
        "We have found enemy messages written in a secret language!",
        "And we need you to decode them!",
        "First, a tour of your computer."
    };
    string[] tourScreens = new string[] {
        "These are your main screens.",
        "The top screen will show the secret message",
        "The bottom screen will show your decoded message",
    };
    string[] tourPlay = new string[] {
        "This is the PLAY button",
        "Click on this button to show your decoded message",
    };
    string[] tourTrash = new string[] {
        "This is the Trash Can",
        "If you've made a mistake, just drag your blocks to the trash can! "
    };

    string[] writeBlockStart = new string[] {
        "Click on the WRITE block!",
    };
    string[] writeBlock = new string[] {
        "This will write the letter to the decoding screen",
    };
    string[] writeBlockConnect = new string[] {
        "Try dragging it under the SHIFT block",
    };
    string[] writeBlockEnd = new string[] {
        "Now press play!"
    };
    string[] startFor = new string[]{
        "Click on the FOR block!",
    };
    string[] forBlock = new string[]{

        "This will read through the enemy message one letter at a time",
        "And you can change what letter to start and end on.",
    };
    string[] endFor = new string[]{
        "Type in 1 and 6 into the Start and End input panels",

    };
    string[] shiftBlockStart = new string[]{
        "Click on the SHIFT block!",
    };
    string[] shiftBlock = new string[]{
        "This will shift a letter forwards in the alphabet",
    };
    string[] shiftBlockInput = new string[]{
        "Type 1 into the input panel",
    };
    string[] shiftBlockConnect = new string[]{
        "Try dragging it inside the FOR block",
    };
    public string[] winTutorial = new string[] {
        "CONGRATULATIONS! You have beaten the test. Press any key to continue..."
    };

    public string[] winRegular = new string[] {
        "CONGRATULATIONS! Press any key to continue..."
    };

    public List<string[]> firstGroupOfTutorialMessages()
    {
        List<string[]> group = new List<string[]>();
        group.Add(tourScreens);
        group.Add(tourPlay);
        group.Add(startFor);
        group.Add(forBlock);
        group.Add(endFor);
        group.Add(shiftBlockStart);
        group.Add(shiftBlock);
        group.Add(shiftBlockInput);
        group.Add(shiftBlockConnect);
        group.Add(writeBlockStart);
        group.Add(writeBlock);
        group.Add(writeBlockConnect);
        group.Add(writeBlockEnd);
        return group;
    }

    string[] preArrowStart = new string[] {
        "You’ve unlocked two new blocks!",
    };
    string[] forRange = new string[] {
        "Type in 1 and 13 into the Start and End input panels",
    };
    string[] ifBlock = new string[]{
        "Click on the IF block!"
    };
    string[] ifInput = new string[]{
        "Type Q into the input panel"
    };
    string[] ifSnap = new string[]{
        "Try dragging it inside the FOR block"
    };

    string[] switchBlock = new string[]{
        "Click on the Switch block!"
    };
    string[] switchInput = new string[]{
        "Type S into the input panel"
    };
    string[] switchSnap = new string[]{
        "Now put it inside of the IF block"
    };

    string[] end = new string[]{
        "Now add a WRITE block below the IF and press play!"
    };
    public List<string[]> secondGroupOfTutorialMessages()
    {
        List<string[]> group = new List<string[]>();
        group.Add(startFor);
        group.Add(forRange);
        group.Add(ifBlock);
        group.Add(ifInput);
        group.Add(ifSnap);
        group.Add(switchBlock);
        group.Add(switchInput);
        group.Add(switchSnap);
        group.Add(end);
        return group;
    }

    string[] level2 = new string[] {
        "We’ve found another coded message!",
        "It looks like all the letters need to be SHIFTed by 5"
    };

    string[] level3 = new string[] {
        "We’ve found another coded message!",
        "It looks like all the B’s should be SHIFTed to E’s"
    };

    string[] level4 = new string[] {
        "You’ve unlocked two new blocks!",
    };

    string[] level5 = new string[] {
        "We’ve found another coded message!",
        "It looks like all the X’s need to be SWITCHed to T’s"
    };

    string[] level6 = new string[] {
        "We’ve found another coded message!",
        "It looks like all the X’s and Z’s need to be replaced"
    };
    string[] level7 = new string[] {
        "We’ve found another coded message!",
        "It looks like the whole message needs to be shifted by 2 ..."
    };
    string[] level8 = new string[] {
        "We’ve found another coded message!",
        "It looks like this message is backwards"
    };

    string[] level9 = new string[] {
        "We’ve found another coded message!",
        "It looks like this message is backwards and shifted"
    };

    public string[] getLevelDialogue(int level)
    {
        Dictionary<int, string[]> levelMap = new Dictionary<int, string[]>{
            {2,level2},
            {3, level3},
            {5, level5},
            {6, level6},
            {7, level7},
            {8, level8},
            {9, level9}
        };
        return levelMap[level];
    }

    public string[] getinitTutorialLevelDialogue(int level)
    {
        Dictionary<int, string[]> levelMap = new Dictionary<int, string[]>{
            {1 , preArrowTutorial},
            {4, preArrowStart},
        };
        return levelMap[level];
    }

    public List<string[]> getTutorialLevelDialogue(int level)
    {
        Dictionary<int, List<string[]>> levelMap = new Dictionary<int, List<string[]>>{
            {1 , firstGroupOfTutorialMessages()},
            {4, secondGroupOfTutorialMessages()},
        };
        return levelMap[level];
    }


}
