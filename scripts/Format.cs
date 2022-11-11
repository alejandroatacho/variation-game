using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// deze class gaat informatie onthouden, als er een speler erop klikt  dan gaat hij 
//zeggen welke type het is (van die image , als het goed of fout is).
public enum PictureTypes
{
    Right,
    Wrong


}

    public class Format : MonoBehaviour
    {
    public string name1;
    public PictureTypes type;
    }

