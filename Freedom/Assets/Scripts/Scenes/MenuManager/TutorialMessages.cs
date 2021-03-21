﻿#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Know;
using XavHelpTo.Look;
using XavHelpTo.Set;
#endregion
public class TutorialMessages : MonoBehaviour
{
    #region Variables
    private int index_ToLoad = -1;
    private bool flag_IsDone;
    private float count_Loads;
    private const string DEFAULT_TEXT = "Haga click izquierdo en alguno de los botones de la derecha para leer más información.";
    private const float ratio_Loads = 0.01f;
    [Header("Tutorial Messages")]
    [Tooltip("Mensajes ordenados en e orden de los botones correspondientes")]
    public Text txt_message;
    [Space]
    [TextArea(3,6)]
    public string[] messages;
    #endregion
    #region Events
    private void Awake()
    {
        AssignText(-1);
    }
    private void Update(){
        //Si no esta completo y estás en el Tick
        if (!flag_IsDone && ratio_Loads.TimerIn(ref count_Loads)){
            LoadInfo();
        }
    }
    #endregion
    #region Method
    /// <summary>
    /// Loads a <see cref="char"/> of the text, advise in <see cref="flag_IsDone"/> whether is Ended
    /// </summary>
    private void LoadInfo(){
        string text = index_ToLoad.Equals(-1) ? DEFAULT_TEXT : messages[index_ToLoad];
        txt_message.text += text[txt_message.text.Length];
        if (txt_message.text.Equals(text)) flag_IsDone = true;
    }
    /// <summary>
    /// Clear any pass text and Set the new text and starts to load it
    /// </summary>
    public void AssignText(int index=-1){
        if (index.Equals(index_ToLoad) && !index.Equals(-1)) return; //🛡
        txt_message.text = "";
        index_ToLoad = index;
        flag_IsDone = false;
    }

    /// <summary>
    /// Clear the showed text
    /// </summary>
    public void ClearText()
    {
        txt_message.text = "";
        index_ToLoad = -1;
        flag_IsDone = true;
    }
    #endregion
}

namespace TutorialButtons
{
    enum TutorialButtons
    {
        CONTROLS=0,
        SAVED=1,
        ELECTIONS=2
    }
}