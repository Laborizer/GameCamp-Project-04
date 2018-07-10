using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public string talk;

    internal string getText()
    {
        return talk;
    }

    internal string getName()
    {
        return this.gameObject.name;
    }
}
