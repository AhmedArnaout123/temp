namespace GgvCsvToSql.Services.FilesManagement;

public class FilesManagementService : IFilesManagementService
{
    private readonly Settings _settings;

    private readonly List<string> _fileNames;

    public FilesManagementService(Settings settings)
    {
        _settings = settings;
        _fileNames = new List<string>
        {
            _settings.OasisCompanyClassFileName,
            _settings.OasisProductClassFileName,
            _settings.OasisContractInventoryClassFileName,
            _settings.OasisContractBookingsPreviousMonthClassFileName,
            _settings.AmsBookingsDataClassFileName,
            _settings.AmsInventoryDataClassFileName,
            _settings.OpenVivaBookingsDataClassFileName,
            _settings.OpenVivaStockDataClassFileName
        };
    }

    public List<string> GetNotImportedFilePaths()
    {
        return GetNotImportedFilePaths(_settings.RootFolderPath);
    }

    private List<string> GetNotImportedFilePaths(string? startPath)
    {
        if (string.IsNullOrWhiteSpace(startPath) || startPath == _settings.ImportedFolderName)
            return new List<string>();
        
        List<string> list = new();
        AppendFiles(startPath, ref list);
        foreach (var directory in Directory.EnumerateDirectories(startPath))
        {
            list.AddRange(GetNotImportedFilePaths(directory));
        }

        return list;
    }

    private void AppendFiles(string path, ref List<string> list)
    {
        var directoryFileNames = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
        foreach (var fileName in directoryFileNames)
        {
            if(_fileNames.Contains(fileName))
                list.Add(fileName);
        }
    }

    public void MoveFileToImportedFolder(string filePath)
    {
        var importedFolderPath = Path.Join(filePath, $"{_settings.RootFolderPath}");
        if (!Directory.Exists(importedFolderPath))
            Directory.CreateDirectory(importedFolderPath);
        
        File.Move(filePath, importedFolderPath);
    }
}