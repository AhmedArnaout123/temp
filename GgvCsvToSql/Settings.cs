namespace GgvCsvToSql;

public class Settings
{
    public string DbConnectionString { get; set; }
    
    public string RootFolderPath { get; set; }
    
    public string ImportedFolderName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into AmsBookingsData class
    /// </summary>
    public string AmsBookingsDataClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into AmsInventoryDataClassFileName class
    /// </summary>
    public string AmsInventoryDataClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OasisCompanyClassFileName class
    /// </summary>
    public string OasisCompanyClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OasisContractBookingsPreviousMonthClassFileName class
    /// </summary>
    public string OasisContractBookingsPreviousMonthClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OasisContractInventoryClassFileName class
    /// </summary>
    public string OasisContractInventoryClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OasisProductClassFileName class
    /// </summary>
    public string OasisProductClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OpenVivaBookingsDataClassFileName class
    /// </summary>
    public string OpenVivaBookingsDataClassFileName { get; set; }
    
    /// <summary>
    /// The file name which will be mapped into OpenVivaStockDataClassFileName class
    /// </summary>
    public string OpenVivaStockDataClassFileName { get; set; }

    public void ValidateAndThrowIfNotValid()
    {
        var reasons = new List<string>();
        
        if(string.IsNullOrWhiteSpace(DbConnectionString))
            reasons.Add(NullOrEmptyValueMessage(nameof(DbConnectionString)));
        if(string.IsNullOrWhiteSpace(RootFolderPath))
            reasons.Add(NullOrEmptyValueMessage(nameof(RootFolderPath)));
        if(string.IsNullOrWhiteSpace(ImportedFolderName))
            reasons.Add(NullOrEmptyValueMessage(nameof(ImportedFolderName)));
        if(string.IsNullOrWhiteSpace(AmsBookingsDataClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(AmsBookingsDataClassFileName)));
        if(string.IsNullOrWhiteSpace(AmsInventoryDataClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(AmsInventoryDataClassFileName)));
        if(string.IsNullOrWhiteSpace(OasisCompanyClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OasisCompanyClassFileName)));
        if(string.IsNullOrWhiteSpace(OasisContractBookingsPreviousMonthClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OasisContractBookingsPreviousMonthClassFileName)));
        if(string.IsNullOrWhiteSpace(OasisProductClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OasisProductClassFileName)));
        if(string.IsNullOrWhiteSpace(OasisContractInventoryClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OasisContractInventoryClassFileName)));
        if(string.IsNullOrWhiteSpace(OpenVivaStockDataClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OpenVivaStockDataClassFileName)));
        if(string.IsNullOrWhiteSpace(OpenVivaBookingsDataClassFileName))
            reasons.Add(NullOrEmptyValueMessage(nameof(OpenVivaBookingsDataClassFileName)));
        
        if(reasons.Any())
            ThrowNotValidException(reasons);
    }

    private void ThrowNotValidException(IEnumerable<string> reasons)
    {
        var message = "Settings class is invalid, detected reasons:\n" + string.Join("\n", reasons);
        throw new Exception(message);
    }

    private string NullOrEmptyValueMessage(string propertyName) => $"{propertyName} is {(propertyName == "" ? "empty" : "null")}";
}