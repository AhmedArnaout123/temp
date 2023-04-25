using GgvCsvToSql.Infrastructure;
using GgvCsvToSql.Services.FilesManagement;
using GgvCsvToSql.Services.FileToEntityMapping;

namespace GgvCsvToSql;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IFilesManagementService _filesManagementService;
    private readonly IFileToEntityMappingService _fileToEntityMappingService;

    public Worker(
        ILogger<Worker> logger, 
        AppDbContext dbContext,
        IFilesManagementService filesManagementService,
        IFileToEntityMappingService fileToEntityMappingService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _filesManagementService = filesManagementService;
        _fileToEntityMappingService = fileToEntityMappingService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var filePaths = _filesManagementService.GetNotImportedFilePaths();
        foreach (var path in filePaths)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var entities =  _fileToEntityMappingService.MapFileToEntities(path);
                await _dbContext.AddRangeAsync(entities);
                _filesManagementService.MoveFileToImportedFolder(path);
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await transaction.RollbackAsync();
            }
        }
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}