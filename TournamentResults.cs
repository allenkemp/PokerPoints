using System.Globalization;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace PokerPoints;
public class TournamentResults
{
  public List<Player> Players { get; set; }
  public String TournamentLabel { get; set; }

  public TournamentResults()
  {
    this.Players = new List<Player>();
    this.TournamentLabel = "";
  }

  public TournamentResults(String tName)
  {
    this.Players = new List<Player>();
    this.TournamentLabel = tName;
  }

  public TournamentResults(String pathToCsvFile, String tName)
  {

    using (var reader = new StreamReader(pathToCsvFile))
    {
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
        
        this.Players = csv.GetRecords<Player>().ToList<Player>();
      }
    }
    CalculateBountyValue();
    CalculateEarnedBountyPoints();
    this.TournamentLabel = tName;
  }

  public void CalculateBountyValue(){
    this.Players.ForEach((p)=>{
      p.BountyPoints = p.Rank <= 10 ? 15 : Players.Count - p.Rank + 1 ;     
    });
  }

  public void CalculateEarnedBountyPoints(){
    this.Players.ForEach((p)=>{
      if(p.Hits > 0){

        double earnedBountyPoints = this.Players.Where(h => h.Hitman == p.Name).Select(i => i.BountyPoints).Sum();
        Console.WriteLine($"{p.Name} earned {earnedBountyPoints} points for knockouts");
        p.PointsEarned = p.PointsEarned + earnedBountyPoints ;
      }
      
    });
  }
}
