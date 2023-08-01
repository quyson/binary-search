/*
    This is essentially creating a custom structure that has a method which involves binary search to return
    a value. This is essentially a dictionary with a string key and list value. This list will be an array 
    of tuples which will have (string value, int time). Initializing a new instance of this class will generate
    an empty dictionary. Setting is straight forward as well, it will simply check if a key exits, and if it doesn't
    then it will create a key with it's respective value. The problem is the getting method which takes in a
    key and time. The method would then have to find the key and then derive the list of tuples as it's value. Then
    perform binary search to find if there is a tuple that actually has the correct time element. If there is, then
    return the value (1st element of tuple). And if the time value doesn't exist then check if there is a closest time value. If there is,
    then return the value.
*/


using System;

class TimeKeyValueStore
{

    private Dictionary<string, List<(string, int)>> content;

    public TimeKeyValueStore()
    {
        content = new Dictionary<string, List<(string, int)>>();
    }

    public void Set(string key, string value, int time)
    {
        if (!content.ContainsKey(key))
        {
            content.Add(key, new List<(string, int)> { (value, time) });
        }
        else
        {
            content[key].Add((value, time));
        }
    }

    public string Get(string key, int time)
    {
        if(!content.ContainsKey(key))
        {
            return "Error";
        }
        if (content.TryGetValue(key, out List<(string, int)> values))
         {
            int left = 0;
            int right = values.Count - 1;

            while(left <= right)
            {   
                int mid = left + (right - left) / 2;
                if (values[mid].Item2 == time)
                {
                    return values[mid].Item1; 
                }
                else if (values[mid].Item2 < time)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (right >= 0)
                {
                    return values[right].Item1;
                }
        }
        return "Error: Value not found for the given time.";
    }
}
