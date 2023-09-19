using DailyPoetryH.Library.Services;

namespace DailyPoetryH.Services;

public class PreferenceStorage :IPreferenceStorage
{
    public void SetPreference(string key, string value)=>Preferences.Set(key, value);

    public int getIntPreference(string key, int defaultValue) => Preferences.Get(key,defaultValue);
}