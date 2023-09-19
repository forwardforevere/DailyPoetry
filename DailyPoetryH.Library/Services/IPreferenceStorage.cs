namespace DailyPoetryH.Library.Services;

public interface IPreferenceStorage
{
    void SetPreference(string key, string value);
    
    int getIntPreference(string key, int defaultValue);
}