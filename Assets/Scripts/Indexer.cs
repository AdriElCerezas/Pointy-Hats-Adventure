using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indexer : MonoBehaviour
{
    GameObject[] Index = new GameObject[4];
    public int index = 0;

    public int SetIndex()
    {
        index++;
        return index-1;
    }
}
