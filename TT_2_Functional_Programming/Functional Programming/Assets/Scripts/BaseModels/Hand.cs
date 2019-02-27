using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;

public class Hand 
{
    private readonly List<Card> cards = new List<Card>();

    // to ensure imutability 
    public IEnumerable<Card> Cards { get { return cards; } }

    public Hand()
    {
    }

    public void Draw(Card card)
    {
        // ensure early exit if card is in the list
        if (isCardInList(card)) return;
        cards.Add(card);
    }

    public Card HighCard()
    {
        return cards.Aggregate((highCard, nextCard) => {
            return nextCard.Value > highCard.Value ? nextCard : highCard;
        });
    }

    public HandRank GetHandRank()
    {
        // return early
        if (HasRoyalFlush()) return HandRank.RoyalFlush;
        if (HasStraightFlush()) return HandRank.StraightFlush;
        if (HasFourOfAKind()) return HandRank.FourOfAKind;
        if (HasFullHouse()) return HandRank.FullHouse;
        if (HasFlush()) return HandRank.Flush;
        if (HasStraight()) return HandRank.Straight;
        if (HasThreeOfAKind()) return HandRank.ThreeOfAKind;
        if (HasTwoPairs()) return HandRank.TwoPair;
        if (HasPair()) return HandRank.Pair;

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

    private bool HasPair()
    {
        return HasOfAKind(2);
    }

    private bool HasTwoPairs()
    {
       
        return HasPair() && HasFlush();
    }

    private bool HasThreeOfAKind()
    {
        return HasOfAKind(3);
    }

    private bool HasFourOfAKind()
    {
        return HasOfAKind(4);
    }

    private bool HasFullHouse()
    {
        return HasThreeOfAKind() && HasPair();
    }

    private bool HasOfAKind(int num)
    {
        return GetKindAndQuantites(cards).Any(c => c.Value == num);
    }

    private bool HasStraightFlush()
    {
        return HasStraight() && HasFlush();
    }

    private bool isCardInList(Card card)
    {
        foreach(Card cardModel in cards)
        {
            if (cardModel.isEqual(card))
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerable<KeyValuePair<CardValue, int>> GetKindAndQuantites(IEnumerable<Card> cards)
    {
        var dict = new ConcurrentDictionary<CardValue, int>();

        foreach(var card in cards)
        {
            dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => ++quantity);
        }

        return dict;
    }

    private bool HasStraight()
    {
        return cards.OrderBy(card => card.Value)
                .Zip(cards.OrderBy(card => card.Value).Skip(1), (n, next) => n.Value + 1 == next.Value)
                .All(value => value /* true */ );
    }
}
