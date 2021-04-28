using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AmeriTrade.API
{
    public class ResponseAPI
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public int refresh_token_expires_in { get; set; }
        public string token_type { get; set; }
        public string error { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class InitialBalances
    {
        public double accruedInterest { get; set; }
        public double availableFundsNonMarginableTrade { get; set; }
        public double bondValue { get; set; }
        public double buyingPower { get; set; }
        public double cashBalance { get; set; }
        public double cashAvailableForTrading { get; set; }
        public double cashReceipts { get; set; }
        public double dayTradingBuyingPower { get; set; }
        public double dayTradingBuyingPowerCall { get; set; }
        public double dayTradingEquityCall { get; set; }
        public double equity { get; set; }
        public double equityPercentage { get; set; }
        public double liquidationValue { get; set; }
        public double longMarginValue { get; set; }
        public double longOptionMarketValue { get; set; }
        public double longStockValue { get; set; }
        public double maintenanceCall { get; set; }
        public double maintenanceRequirement { get; set; }
        public double margin { get; set; }
        public double marginEquity { get; set; }
        public double moneyMarketFund { get; set; }
        public double mutualFundValue { get; set; }
        public double regTCall { get; set; }
        public double shortMarginValue { get; set; }
        public double shortOptionMarketValue { get; set; }
        public double shortStockValue { get; set; }
        public double totalCash { get; set; }
        public bool isInCall { get; set; }
        public double pendingDeposits { get; set; }
        public double marginBalance { get; set; }
        public double shortBalance { get; set; }
        public double accountValue { get; set; }
    }
    [JsonObject(Title = "currentBalances")]
    public class CurrentBalances
    {
        public double accruedInterest { get; set; }
        public double cashBalance { get; set; }
        public double cashReceipts { get; set; }
        public double longOptionMarketValue { get; set; }
        public double liquidationValue { get; set; }
        public double longMarketValue { get; set; }
        public double moneyMarketFund { get; set; }
        public double savings { get; set; }
        public double shortMarketValue { get; set; }
        public double pendingDeposits { get; set; }
        public double availableFunds { get; set; }
        public double availableFundsNonMarginableTrade { get; set; }
        public double buyingPower { get; set; }
        public double buyingPowerNonMarginableTrade { get; set; }
        public double dayTradingBuyingPower { get; set; }
        public double equity { get; set; }
        public double equityPercentage { get; set; }
        public double longMarginValue { get; set; }
        public double maintenanceCall { get; set; }
        public double maintenanceRequirement { get; set; }
        public double marginBalance { get; set; }
        public double regTCall { get; set; }
        public double shortBalance { get; set; }
        public double shortMarginValue { get; set; }
        public double shortOptionMarketValue { get; set; }
        public double sma { get; set; }
        public double mutualFundValue { get; set; }
        public double bondValue { get; set; }
    }

    public class ProjectedBalances
    {
        public double availableFunds { get; set; }
        public double availableFundsNonMarginableTrade { get; set; }
        public double buyingPower { get; set; }
        public double dayTradingBuyingPower { get; set; }
        public double dayTradingBuyingPowerCall { get; set; }
        public double maintenanceCall { get; set; }
        public double regTCall { get; set; }
        public bool isInCall { get; set; }
        public double stockBuyingPower { get; set; }
    }

    [DataContract(Name = "securitiesAccount")]
    public class SecuritiesAccount
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("accountId")]
        public string accountId { get; set; }

        [JsonProperty("roundTrips")]
        public int roundTrips { get; set; }

        [JsonProperty("isDayTrader")]
        public bool isDayTrader { get; set; }

        [JsonProperty("isClosingOnlyRestricted")]
        public bool isClosingOnlyRestricted { get; set; }

        [JsonProperty("initialBalances")] 
        public InitialBalances initialBalances { get; set; }

        [JsonProperty("currentBalances")] 
        public CurrentBalances currentBalances { get; set; }

        [JsonProperty("projectedBalances")] 
        public ProjectedBalances projectedBalances { get; set; }
    }

    public class Root
    {
        public SecuritiesAccount securitiesAccount { get; set; }
    }
}
