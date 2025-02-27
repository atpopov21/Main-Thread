namespace Main_Thread.DAL.Models;

public class Profit
{
    public int Id { get; set; }
    public decimal DailyProfit { get; set; }
    public DateTime Date { get; set; }
    public int BusinessId { get; set; }
}