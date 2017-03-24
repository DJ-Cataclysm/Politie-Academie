using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSettings : MonoBehaviour {

    public static int friendlyNPC;
    public static int enemyNPC;
    public static int idleNPC;

    [SerializeField] private Text InputFieldText;

    public void setFriendly(){
        friendlyNPC = Convert.ToInt32(InputFieldText.text.ToString());
    }
    public void setEnemy() {
        enemyNPC = Convert.ToInt32(InputFieldText.text.ToString());
    }
    public void setIdle() {
        idleNPC = Convert.ToInt32(InputFieldText.text.ToString());
    }
}
