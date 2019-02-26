using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HandModel 
{
    private readonly List<CardModel> cards = new List<CardModel>();

    // to ensure imutability 
    public IEnumerable<CardModel> Cards { get { return cards; } }

    public HandModel()
    {
    }

    public void Draw(CardModel card)
    {
        cards.Add(card);
    }
}
