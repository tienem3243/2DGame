using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
   private Queue<string> sentenses;
    [Tooltip("Character Name")] public Text charName;
    public Text dialogText;
    public Animator animDialog;
    private void Start()
    {
        sentenses = new Queue<string>();
    }
    public void DialogStart(Dialog dialog)
    {
        animDialog.SetTrigger("IsOpening");
        Debug.Log("Start conservation with" + dialog.name);
        charName.text = dialog.name;
        sentenses.Clear();
        foreach(string sentence in dialog.sentenses)
        {
            sentenses.Enqueue(sentence);
        }
        DislayNextSentence();
    }
    public void DislayNextSentence()
    {
        if (sentenses.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentenses.Dequeue();
        dialogText.text = sentence;
        Debug.Log(sentence);
    }
    public void EndDialog()
    {
        animDialog.SetTrigger("IsClose");
        Debug.Log("End of conservation");
    }
}
