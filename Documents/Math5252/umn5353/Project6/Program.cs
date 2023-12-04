using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApp{

    class Program {

    [Table("Exchanges")]
        public class Exchange
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ShortCode {get; set;}
    }
    [Table("Market")]
    public class Market
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    [Table("Units")]
    public class Units
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public double Quantity {get;set;}
    }
    
    [Table("Underlying")]
    public class Underlying
    {
        public Exchange Exchange {get; set;}
        public int ExchangeId {get; set;}

        public int Id {get; set;}
        public string CorpName {get; set;}
        public string Ticker {get; set;}
    }
    [Table("Options")]
    public class Option
    {
        public int Id {get; set;}
        public Underlying Underlying {get; set;}
        public DateTimeOffset ExpirationDate {get; set;}
    }
    [Table("European")]
    public class European : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Asian")]
    public class Asian : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Digital")]
    public class Digital : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
        public double payout {get; set;}
    }
    [Table("Lookback")]
    public class Lookback : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Barrier")]
    public class Barrier : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
        public int BarrierTypeID {get; set;}
        public double BarrierLevel {get; set;}
    }
    [Table("Range")]
    public class Range : Option
    {
       
    }
    [Table("HistoricalPrice")]
    public class HistoricalPrice
    {
        public int Id {get;set;}
        public Underlying Underlying {get;set;}
        public int UnderlyingId {get; set;}
        public double Price {get;set;}
        public DateTimeOffset Date {get;set;}
    }
    [Table("Trade")]
    public class Trade
    {
        public int Id {get; set;}
        public double Quantity {get; set;}
        public Underlying Instrument {get; set;}

        public double Price {get; set;}
        public DateTimeOffset Date {get; set;}
    }
    [Table("TradeEvaluation")]
    public class TradeEvaluation
    {
        public int Id {get; set;}
        public double MarketValue {get; set;}
        // add greeks 
    }
    public class Context : DbContext
    {
        public DbSet<Option> Options {get; set;}
        public DbSet<Exchange> Exchanges {get; set;}
        //public DbSet<Instrument> Instruments {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=montecarlo;Username=postgress;Password=root") ;
    }
    

    }
}


