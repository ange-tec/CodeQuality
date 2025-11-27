namespace CodeQuality.Samples.CleanCode.Yahtzee;

/// <summary>
/// Objectif N°1: Refactorer le code selon les principes/pratiques de Clean Code
/// Objectif N°2: Exposer une seule méthode Evaluate(...) qui retournera la liste des figures possibles, avec leur score associé.
/// </summary>
public class YahtzeeGame
{
    protected int[] dice;

    public YahtzeeGame()
    {
    }

    public YahtzeeGame(int d1, int d2, int d3, int d4, int _5)
    {
        dice = new int[5];
        dice[0] = d1;
        dice[1] = d2;
        dice[2] = d3;
        dice[3] = d4;
        dice[4] = _5;
    }

    public static int Chance(int d1, int d2, int d3, int d4, int d5)
    {
        return d1 + d2 + d3 + d4 + d5;
    }

    public int Fives()
    {
        int diceValue = 5;
        return this.dice.Where(d => d == diceValue ).Sum();
    }
    
    public static int FourOfAKind(int _1, int _2, int d3, int d4, int d5)
    {
        int[] tallies = new int[6];
        tallies[_1 - 1]++;
        tallies[_2 - 1]++;
        tallies[d3 - 1]++;
        tallies[d4 - 1]++;
        tallies[d5 - 1]++;
        return CountSameDice(tallies, 4);
    }

    public static int CountSameDice(int[] tallies, int target)
    {
        for (var i = 0; i < tallies.Length; i++)
            if (tallies[i] >= 4)
                return (i + 1) * 4;
        return 0;
    }
    public int Fours()
    {
        int diceValue = 4;
            
        return this.AddSomeDice(4);
    }

    public int AddSomeDice(int diceValue)
    {
        return this.dice.Where(d => d == diceValue).Sum();
    }
    public static int FullHouse(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        var _2 = false;
        int i;
        var _2_at = 0;
        var _3 = false;
        var _3_at = 0;


        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;

        for (i = 0; i != 6; i += 1)
            if (tallies[i] == 2)
            {
                _2 = true;
                _2_at = i + 1;
            }

        for (i = 0; i != 6; i += 1)
            if (tallies[i] == 3)
            {
                _3 = true;
                _3_at = i + 1;
            }

        if (_2 && _3)
            return _2_at * 2 + _3_at * 3;
        return 0;
    }

    public static int LargeStraight(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;
        if (tallies[1] == 1 &&
            tallies[2] == 1 &&
            tallies[3] == 1 &&
            tallies[4] == 1
            && tallies[5] == 1)
            return 20;
        return 0;
    }

    public int Ones()
    {
        int diceValue = 1;
        return this.dice.Where(d => d == diceValue).Sum();
    }

    public int ScorePair(int d1, int d2, int d3, int d4, int d5)
    {
        var counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        int at;
        for (at = 0; at != 6; at++)
            if (counts[6 - at - 1] >= 2)
                return (6 - at) * 2;
        return 0;
    }

    public int sixes()
    {
        int diceValue = 6;
        return this.dice.Where(d => d == diceValue ).Sum();
    }

    public static int SmallStraight(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;
        if (tallies[0] == 1 &&
            tallies[1] == 1 &&
            tallies[2] == 1 &&
            tallies[3] == 1 &&
            tallies[4] == 1)
            return 15;
        return 0;
    }

    public static int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5)
    {
        int[] t;
        t = new int[6];
        t[d1 - 1]++;
        t[d2 - 1]++;
        t[d3 - 1]++;
        t[d4 - 1]++;
        t[d5 - 1]++;
        return CountSameDice(tallies: [], 3);
    }

    public int Threes()
    {
        int diceValue  = 3;
        return this.dice.Where(d => d == diceValue).Sum();
    }

    public static int TwoPair(int d1, int d2, int d3, int d4, int d5)
    {
        var counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        var n = 0;
        var score = 0;
        for (var i = 0; i < 6; i += 1)
            if (counts[6 - i - 1] >= 2)
            {
                n++;
                score += 6 - i;
            }

        if (n == 2)
            return score * 2;
        return 0;
    }

    public int Twos()
    {
        int diceValue = 2;
        return this.dice.Where(d => d == diceValue).Sum();
    }

    public static int Yahtzee(params int[] dice)
    {
        var counts = new int[6];
        foreach (var die in dice)
            counts[die - 1]++;
        for (var i = 0; i != 6; i++)
            if (counts[i] == 5)
                return 50;
        return 0;
    }
}