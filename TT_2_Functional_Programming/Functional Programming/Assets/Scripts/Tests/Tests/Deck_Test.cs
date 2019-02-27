using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class Deck_Test {

    [Test]
    public void Deck_TestSimplePasses() {
        // Use the Assert class to test conditions.
        Deck deck = new Deck();

        Assert.AreEqual(deck.Cards.Count(), 52);
    }

    //[Test]
    //public void Deck_PrintCards()
    //{
    //    // Use the Assert class to test conditions.
    //    Deck deck = new Deck();

    //    Assert.AreEqual(deck.Cards.Count(), 52);

    //    foreach(Card card in deck.Cards)
    //    {
    //        Debug.Log(card.ToString());
    //    }
    //}

    [Test]
    public void Deck_CheckRandomization()
    {
        // Create two decks.
        Deck deck_A = new Deck();
        Deck deck_B = new Deck();

        // and compare are the two list a different
        Assert.False(deck_A.Cards.SequenceEqual(deck_B.Cards));
         
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator Deck_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
