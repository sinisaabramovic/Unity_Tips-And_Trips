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

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator HandModel_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
