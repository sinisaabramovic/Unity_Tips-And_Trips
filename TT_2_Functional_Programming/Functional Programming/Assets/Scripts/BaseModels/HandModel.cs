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
        // ensure early exit if card is in the list
        if (isCardModelInList(card)) return;
        cards.Add(card);
    }

    public CardModel HighCard()
    {
        return cards.Aggregate((highCard, nextCard) => {
            return nextCard.Value > highCard.Value ? nextCard : highCard;
        });
    }

    public HandRank GetHandRank()
    {
        if (HasRoyalFlush()) return HandRank.RoyalFlush;
        if (HasFlush()) return HandRank.Flush;

        return HandRank.HighCard;
    }

    private bool HasFlush()
    {
        return cards.All((c) => {
            return cards.First().Suit == c.Suit;
        });
    }

    private bool HasRoyalFlush()
    {
        return HasFlush() && cards.All((c) => {
            return c.Value > CardValue.Nine;
        });
    }

    private bool isCardModelInList(CardModel card)
    {
        foreach(CardModel cardModel in cards)
        {
            if (cardModel.isEqual(card))
            {
                return true;
            }
        }

        return false;
    }
}
