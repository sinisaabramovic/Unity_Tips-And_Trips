using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class HandModel_Test {

    [Test]
    public void HandModel_TestSimplePasses() {
        // Use the Assert class to test conditions.
        HandModel hand = new HandModel();
        Assert.False(hand.Cards.Any());
    }

    [Test]
    public void HandModel_CanDrawAAcard()
    {
        CardModel card = new CardModel(CardValue.Ace, CardSuit.Spades);
        HandModel hand = new HandModel();

        hand.Draw(card);

        CardModel cardDump = new CardModel(CardValue.Eight, CardSuit.Spades);

        Assert.AreEqual(hand.Cards.First(), card);
    }

    [Test]
    public void IsCardDuplicates()
    {
        HandModel hand = new HandModel();
        int expectedCount = 5;

        hand.Draw(new CardModel(CardValue.Seven, CardSuit.Clubs));
        hand.Draw(new CardModel(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.King, CardSuit.Spades));
        hand.Draw(new CardModel(CardValue.Two, CardSuit.Clubs));
        // This a duplicates
        hand.Draw(new CardModel(CardValue.Two, CardSuit.Clubs));
        hand.Draw(new CardModel(CardValue.Ten, CardSuit.Hearts));

        Assert.AreEqual(hand.Cards.Distinct().Count(), expectedCount);
    }

    [Test]
    public void CanGetHighCard()
    {
        HandModel hand = new HandModel();
        hand.Draw(new CardModel(CardValue.Seven, CardSuit.Clubs));
        hand.Draw(new CardModel(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.King, CardSuit.Spades));
        hand.Draw(new CardModel(CardValue.Two, CardSuit.Clubs));

        Assert.AreEqual(CardValue.King, hand.HighCard().Value);
    }

    [Test]
    public void CanScoreAFlush()
    {
        HandModel hand = new HandModel();
        hand.Draw(new CardModel(CardValue.Seven, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.King, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Two, CardSuit.Hearts));

        Assert.AreEqual(HandRank.Flush, hand.GetHandRank());
    }

    [Test]
    public void CanScoreARoyalFlush()
    {
        HandModel hand = new HandModel();
        hand.Draw(new CardModel(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.King, CardSuit.Hearts));
        hand.Draw(new CardModel(CardValue.Ace, CardSuit.Hearts));

        Assert.AreEqual(HandRank.RoyalFlush, hand.GetHandRank());
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator HandModel_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
