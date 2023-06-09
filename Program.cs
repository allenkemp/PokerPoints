namespace PokerPoints;
class Program
{
  public static void Main(string[] args)
  {
    TournamentResults myTourney = new TournamentResults("wsop_test.csv", "test");
    myTourney.Players.ForEach((p)=>Console.WriteLine(p.ToString()));

  }
}