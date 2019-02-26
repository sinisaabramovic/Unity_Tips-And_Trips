using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HandModel 
{
    public List<CardModel> Cards { get; }

    public HandModel()
    {
        Cards = new List<CardModel>();
    }

    public void Draw(CardModel card)
    {
        Cards.Add(card);
    }
}
