using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighCardStrategy : IScoreStrategy
{
    private int scoreValue = 0;

    public int ScoreValue
    {
        get
        {
            return scoreValue;
        }
    }

    public int GetScore()
    {
        return scoreValue;
    }
}

public class Score
{
    private static Score sharedInstance = null;
    private static readonly object padlockInstance = new object();

    private static Dictionary<HandRank, int> scoreSet;
    private static int multiplier = Constants.SharedInstance.BaseMultiplierValue;
    private static int score = Constants.SharedInstance.NullValue;

    private Score() { }

    public static Score SharedInstance
    {
        get
        {
            lock (padlockInstance)
            {
                if (sharedInstance == null)
                {
                    sharedInstance = new Score();
                    scoreSet = new Dictionary<HandRank, int>();
                    InitScoreSets();
                }
            }
            return sharedInstance;
        }
    }

    public static int GetScore(HandRank forRank)
    {
        return scoreSet[forRank] * multiplier;
    }

    public static void SetScore(int value)
    {
        score += value;
    }

    public static void ResetScore()
    {
        score = Constants.SharedInstance.ResetScoreValue;
    }

    public static bool SetMultiplier(int value)
    {
        if (value > Constants.SharedInstance.MaximumBetAmount && value < Constants.SharedInstance.MinumumBetAmount) return false;
        multiplier = value;
        return true;
    }

    private static void InitScoreSets()
    {
        scoreSet.Add(HandRank.Flush, (int)HandRank.Flush);
        scoreSet.Add(HandRank.FourOfAKind, (int)HandRank.FourOfAKind);
        scoreSet.Add(HandRank.FullHouse, (int)HandRank.FullHouse);
        scoreSet.Add(HandRank.HighCard, Constants.SharedInstance.NullValue);
        scoreSet.Add(HandRank.Pair, (int)HandRank.Pair);
        scoreSet.Add(HandRank.RoyalFlush, (int)HandRank.RoyalFlush);
        scoreSet.Add(HandRank.Straight, (int)HandRank.Straight);
        scoreSet.Add(HandRank.StraightFlush, (int)HandRank.StraightFlush);
        scoreSet.Add(HandRank.ThreeOfAKind, (int)HandRank.ThreeOfAKind);
        scoreSet.Add(HandRank.TwoPair, (int)HandRank.TwoPair);
    }

}
