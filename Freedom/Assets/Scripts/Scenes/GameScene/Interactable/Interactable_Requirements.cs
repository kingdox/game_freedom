﻿#region Access
using UnityEngine;
using XavHelpTo.Know;

#endregion
public partial class Interactable
{
    #region Variables
    [Header("_Requirements")]
    [Range(0, 10f)]
    public float distanceRequired = 0f; // where 0 == does not required
    //[Space]
    public int[] itemsRequireds;
    #endregion
    #region Methods



    /// <summary>
    /// Check the interaction between the target and the transform of this gameoobject
    /// </summary>
    partial void CheckRequirements()
    {
        //🛡
        if (PlayerController.tr_player.IsNull()) return;
        //🛡

        // if the distance is zero then its true...
        isNear = distanceRequired.Equals(0) || !PlayerController.tr_player.IsNull()
            && Vector3.Distance( transform.position, PlayerController.tr_player.position ) <= distanceRequired
        ;

        //si no hay requerimientos ó los requeridos se encuentran
        haveItems = itemsRequireds.Length.Equals(0)
            || itemsRequireds.Contains(TheatreManager.CurrentItems);
    }

    #endregion
}