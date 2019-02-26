using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel  
{
    // only expose getter to ensure immutability
    public CardValue Value { get; }
    public CardSuit Suit { get; }

    public CardModel(CardValue value, CardSuit suit)
    {
        Value = value;
        Suit = suit;
    }

    public bool isEqual(CardModel card)
    {
        return Value == card.Value && Suit == card.Suit;
    }

    public override string ToString() => $"{Value} of {Suit}";

}
