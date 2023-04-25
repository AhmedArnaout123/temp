using System.Globalization;
using CsvHelper;
using GgvCsvToSql.Models;

namespace GgvCsvToSql.Services.FileToEntityMapping;

public class FileToEntityMappingService : IFileToEntityMappingService
{
    private readonly Settings _settings;

    public FileToEntityMappingService(Settings settings)
    {
        _settings = settings;
    }

    public List<EntityBase> MapFileToEntities(string path)
    {
        var fileName = Path.GetFileName(path);
        if(string.IsNullOrWhiteSpace(fileName))
            ThrowInvalidPathException(fileName);

        var fileExtension = Path.GetExtension(path).ToLower();
        if(fileExtension != ".csv")
            ThrowInvalidFileExtnesionException(fileExtension);
        
        using (var reader = new StreamReader(fileName))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            IEnumerable<EntityBase> records = Enumerable.Empty<EntityBase>();
            if(fileName == _settings.OasisCompanyClassFileName)
                records = csv.GetRecords<OasisCompany>();
            else if(fileName == _settings.OasisProductClassFileName)
                records = csv.GetRecords<OasisProduct>();
            else if(fileName == _settings.OasisProductClassFileName)
                records = csv.GetRecords<OasisProduct>();
            else if(fileName == _settings.OasisContractInventoryClassFileName)
                records = csv.GetRecords<OasisContractInventory>();
            else if(fileName == _settings.OasisContractBookingsPreviousMonthClassFileName)
                records = csv.GetRecords<OasisContractBookingsPreviousMonth>();
            else if(fileName == _settings.AmsBookingsDataClassFileName)
                records = csv.GetRecords<AmsBookingsData>();
            else if(fileName == _settings.AmsInventoryDataClassFileName)
                records = csv.GetRecords<AmsInventoryData>();
            else if(fileName == _settings.OpenVivaBookingsDataClassFileName)
                records = csv.GetRecords<OpenVivaBookingsData>();
            else if(fileName == _settings.OpenVivaStockDataClassFileName)
                records = csv.GetRecords<OpenVivaStockData>();
            else
                ThrowUnknownFileNameException(fileName);

            return records.ToList();
        }
    }

    private void ThrowInvalidPathException(string path)
    {
        throw new Exception(
            $"{nameof(FileToEntityMappingService)}.{nameof(MapFileToEntities)} was invoked with invalid path: {path}");
    }
    
    private void ThrowInvalidFileExtnesionException(string fileExtension)
    {
        throw new Exception(
            $"{nameof(FileToEntityMappingService)}.{nameof(MapFileToEntities)} was invoked with invalid file extension: {fileExtension}");
    }
    
    private void ThrowUnknownFileNameException(string fileName)
    {
        throw new Exception(
            $"{nameof(FileToEntityMappingService)}.{nameof(MapFileToEntities)} was invoked with invalid file name: {fileName}");
    }
}