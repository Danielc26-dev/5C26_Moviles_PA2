using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NuevoScriptableObject", menuName = "scriptables/frutas")]
public class scriptableFrutas : ScriptableObject
{
    public GameObject whole;
    public GameObject sliced;

    public int points = 1;

}
