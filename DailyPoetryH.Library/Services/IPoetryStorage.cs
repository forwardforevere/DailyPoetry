namespace DailyPoetryH.Library.Services;

public interface IPoetryStorage {
    bool IsInitialized { get; }
    
    Task  InitializeAsync();
}