using Xunit;

namespace MidInterviewTest;

/*
    Given a string s, 
    find the first non-repeating character in it and return its index. 
    If it does not exist, return -1.
*/
public static class Finder {
    static Dictionary<char, int> d = new();
    public static int FirstUniqChar(string s)
    {
        for (int i = 0; i < s.Length; i++)
            d[s[i]]++;

        for (int i = 0; i < s.Length; i++)
            if (d[s[i]] == 1)
                return i;
        
        return -1;
    }
}

