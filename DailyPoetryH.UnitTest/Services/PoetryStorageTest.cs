using DailyPoetryH.Library.Services;
using DailyPoetryH.UnitTest.Helpers;
using Moq;

namespace DailyPoetryH.UnitTest.Services;

public class PoetryStorageTest : IDisposable
{
    public PoetryStorageTest() 
    {
        PoetryStorageHelper.RemoveDatabaseFile();
    }
    public void Dispose()
    {
        // TODO 在此释放托管资源
        PoetryStorageHelper.RemoveDatabaseFile();
    }
    
    [Fact]
    public void IsInitialized_Initialized()
    { 
        
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        preferenceStorageMock
            .Setup(p => p.getIntPreference(PoetryStorageConstant.DbVersionKey, 0))
            .Returns(PoetryStorageConstant.version);
        
        
        var poetryStorage=new PoetryStorage(preferenceStorageMock.Object);
        Assert.True(poetryStorage.IsInitialized);
    }
    
    [Fact]
    public void IsInitialized_NotInitialized()
    { 
        
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        preferenceStorageMock
            .Setup(p => p.getIntPreference(PoetryStorageConstant.DbVersionKey, 0))
            .Returns(0);
        
        
        var poetryStorage=new PoetryStorage(preferenceStorageMock.Object);
        Assert.False(poetryStorage.IsInitialized);
    }

    [Fact]
    public async Task InitializeAsync_Default() {
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        var mockPreferenceStorage = preferenceStorageMock.Object;
        var poetryStorage=new PoetryStorage(mockPreferenceStorage);
        Assert.False(File.Exists(PoetryStorage.PoetryDbPath));
        await poetryStorage.InitializeAsync();
        Assert.True(File.Exists(PoetryStorage.PoetryDbPath));
    }

    
}  