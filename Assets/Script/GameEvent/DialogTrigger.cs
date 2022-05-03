using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public DialogManager dialogManager;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogManager.DialogStart(dialog);
    }
}
