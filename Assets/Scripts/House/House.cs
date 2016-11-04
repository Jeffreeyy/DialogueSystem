using UnityEngine;
using System.Collections;

public class House : MonoBehaviour
{
    [SerializeField]private int _houseID;
    [SerializeField]private AudioSource _doorBellSound;
    public delegate void LoadDialogue(int dialogue);
    public static LoadDialogue OnLoadDialogue;

    public void Ring()
    {
        _doorBellSound.Play();
        if(OnLoadDialogue != null)
        {
            OnLoadDialogue(_houseID);
        }
    }
}
