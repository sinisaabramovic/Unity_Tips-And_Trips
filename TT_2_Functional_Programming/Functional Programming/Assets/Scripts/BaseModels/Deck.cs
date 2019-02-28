﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;

public class Deck  
{

    private readonly List<Card> cards = new List<Card>();

    // to ensure imutability 
    public IEnumerable<Card> Cards { get { return cards; } }

    public Deck()
    {
        InitializeDeck();
        cards = ShuffleDeck();
    }

    private List<Card> ShuffleDeck()
    {
        var randomNumber = new System.Random(52);
        var randomizedCards = cards.OrderBy(r => randomNumber.Next());

        return randomizedCards.ToList();
    }

    public Card ThrowCard()
    {
        if (cards.Count() <= 0) return null;

        Card card = cards.Last();
        cards.Remove(card);

        return card;
    }

    public List<Card> ThrowCards(int numberOfCards)
    {
        if (cards.Count() < numberOfCards &&  numberOfCards > 0) return null;

        List<Card> throwableCards = new List<Card>();

       for(int i=0; i < numberOfCards; i++)
        {
            throwableCards.Add(ThrowCard());
        }

        return throwableCards;
    }

    private void InitializeDeck()
    {
        // Set of Clubs
        cards.Add(new Card(CardValue.Two, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Three, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Four, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Five, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Six, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Seven, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Eight, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Nine, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Ten, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Jack, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Queen, CardSuit.Clubs));
        cards.Add(new Card(CardValue.King, CardSuit.Clubs));
        cards.Add(new Card(CardValue.Ace, CardSuit.Clubs));
        // Set of Diamonds
        cards.Add(new Card(CardValue.Two, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Three, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Four, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Five, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Six, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Seven, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Eight, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Nine, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Ten, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Jack, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Queen, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.King, CardSuit.Diamonds));
        cards.Add(new Card(CardValue.Ace, CardSuit.Diamonds));
        // Set of Hearts
        cards.Add(new Card(CardValue.Two, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Three, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Four, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Five, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Six, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Seven, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Eight, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Nine, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Ten, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Jack, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Queen, CardSuit.Hearts));
        cards.Add(new Card(CardValue.King, CardSuit.Hearts));
        cards.Add(new Card(CardValue.Ace, CardSuit.Hearts));
        // Set of Spades
        cards.Add(new Card(CardValue.Two, CardSuit.Spades));
        cards.Add(new Card(CardValue.Three, CardSuit.Spades));
        cards.Add(new Card(CardValue.Four, CardSuit.Spades));
        cards.Add(new Card(CardValue.Five, CardSuit.Spades));
        cards.Add(new Card(CardValue.Six, CardSuit.Spades));
        cards.Add(new Card(CardValue.Seven, CardSuit.Spades));
        cards.Add(new Card(CardValue.Eight, CardSuit.Spades));
        cards.Add(new Card(CardValue.Nine, CardSuit.Spades));
        cards.Add(new Card(CardValue.Ten, CardSuit.Spades));
        cards.Add(new Card(CardValue.Jack, CardSuit.Spades));
        cards.Add(new Card(CardValue.Queen, CardSuit.Spades));
        cards.Add(new Card(CardValue.King, CardSuit.Spades));
        cards.Add(new Card(CardValue.Ace, CardSuit.Spades));

    }
}
