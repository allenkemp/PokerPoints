using CsvHelper.Configuration.Attributes;

namespace PokerPoints;
public class Player
{
  [Name("Rank")]
  public int Rank { get; set; }
  [Name("Name")]
  public String Name { get; set; }
  [Name("Points")]
  public Double PointsEarned { get; set; }
  [Ignore]
  public Double BountyPoints { get; set; }
  [Name("Hits"), CsvHelper.Configuration.Attributes.Default(0)]
  public int Hits { get; set; }
  [Name("Hitman")]
  public String Hitman { get; set; }

  public override string ToString() => $"Name: {this.Name} | Finish: {this.Rank} | Total Points Earned: {this.PointsEarned} | Bounty Value: {this.BountyPoints}";
}
