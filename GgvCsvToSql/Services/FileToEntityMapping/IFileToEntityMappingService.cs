using GgvCsvToSql.Models;

namespace GgvCsvToSql.Services.FileToEntityMapping;

public interface IFileToEntityMappingService
{
    public List<EntityBase> MapFileToEntities(string filePath);
}