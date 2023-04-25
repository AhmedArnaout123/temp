namespace GgvCsvToSql.Services.FilesManagement;

public interface IFilesManagementService
{
    public List<string> GetNotImportedFilePaths();

    public void MoveFileToImportedFolder(string filePath);
}