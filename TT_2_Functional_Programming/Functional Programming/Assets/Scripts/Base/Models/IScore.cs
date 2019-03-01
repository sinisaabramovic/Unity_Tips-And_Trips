using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreStrategy 
{
    int ScoreValue
    {
        get;
    }
    int GetScore();

}
