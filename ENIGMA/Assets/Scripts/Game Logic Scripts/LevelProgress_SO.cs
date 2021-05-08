using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelProgress", menuName = "LevelProgress")]
public class LevelProgress_SO : ScriptableObject
{

    public Message_SO tutorial1;
    public Message_SO level2;
    public Message_SO level3;
    public Message_SO tutorial4;
    public Message_SO level5;
    public Message_SO level6;
    public Message_SO level7;
    public Message_SO level8;
    public Message_SO level9;

    public bool tut1_unlocked = true;
    public bool lvl2_unlocked => tutorial1.solved;
    public bool lvl3_unlocked => level2.solved & tutorial1.solved;
    public bool tut4_unlocked => level3.solved & level2.solved & tutorial1.solved;
    public bool lvl5_unlocked => tutorial4.solved & level3.solved & level2.solved & tutorial1.solved;
    public bool lvl6_unlocked => level5.solved & tutorial4.solved & level3.solved & level2.solved & tutorial1.solved;
    public bool lvl7_unlocked => lvl6_unlocked & level5.solved & tutorial4.solved & level3.solved & level2.solved & tutorial1.solved;
    public bool lvl8_unlocked => lvl7_unlocked & lvl6_unlocked & level5.solved & tutorial4.solved & level3.solved & level2.solved & tutorial1.solved;
    public bool lvl9_unlocked => lvl8_unlocked & lvl7_unlocked & lvl6_unlocked & level5.solved & tutorial4.solved & level3.solved & level2.solved & tutorial1.solved;
}
