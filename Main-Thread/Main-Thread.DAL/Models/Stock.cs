namespace Main_Thread.DAL.Models;

public class Stock
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; } 
    public string Category { get; set; }
    public decimal Rating { get; set; }
    public int BusinessId { get; set; }

}