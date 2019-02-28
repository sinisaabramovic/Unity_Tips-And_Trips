using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DrawCardFromDeck_Test {

    [Test]
    public void DrawCardFromDeck_TestSimplePasses() {
        // Use the Assert class to test conditions.
        int numberOFClaimedCards = 5;
        Deck deck = new Deck();
        Hand hand = new Hand();

        hand.ClaimForCards((count) => {

            List<Card> cards = new List<Card>();
            cards = deck.ThrowCards(count);

            foreach(Card card in cards)
            {
                hand.Draw(card);
            }

        }, numberOFClaimedCards);

        Debug.Log(hand.ToString());

        Assert.AreEqual(hand.Cards.Count(), numberOFClaimedCards);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DrawCardFromDeck_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
