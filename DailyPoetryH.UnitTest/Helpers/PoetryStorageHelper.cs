using DailyPoetryH.Library.Services;

namespace DailyPoetryH.UnitTest.Helpers;

public class PoetryStorageHelper
{
    public static void RemoveDatabaseFile() => File.Delete(PoetryStorage.PoetryDbPath);
}