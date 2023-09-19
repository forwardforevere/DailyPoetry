namespace DailyPoetryH.Library.Services;

public class PoetryStorage : IPoetryStorage
{
    private readonly IPreferenceStorage _preferenceStorage;
    private const string DbName = "poetry.db";

    public static readonly string PoetryDbPath=Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        DbName);
    
    //使用构造函数 而不是属性注入
    public PoetryStorage(IPreferenceStorage preferenceStorage)
    {
        _preferenceStorage = preferenceStorage;
    }

    public bool IsInitialized => 
        _preferenceStorage.getIntPreference(PoetryStorageConstant.DbVersionKey,0) 
        == PoetryStorageConstant.version;

    
    public async Task InitializeAsync()
    {
        await using var dbFileStream = new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
        await using var dbAssetStream = typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName);
        await dbAssetStream.CopyToAsync(dbFileStream); //copy 一个文件流到另一个文件流
        _preferenceStorage.SetPreference(PoetryStorageConstant.DbVersionKey, PoetryStorageConstant.version.ToString());
    }
}

public static class PoetryStorageConstant
{
    public const string DbVersionKey =
        nameof(PoetryStorageConstant) + "." + nameof(DbVersionKey);

    public const int version = 1;
}