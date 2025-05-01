using Xunit;

namespace MidInterviewTest;

/**
    Implement the Least Recently Used (LRU) cache class:
    LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    int get(int key) Return the value of the key if the key exists, otherwise return -1.
    void put(int key, int value) Update the value of the key if the key exists.
    Otherwise, add the key-value pair to the cache. If the number of keys exceeds
    the capacity from this operation, evict the least recently used key.
    
    Extra:
    The functions get and put must each run in O(1) average time complexity.
    
    LRUCache lRUCache = new LRUCache(2);
    lRUCache.put(1, 1); // cache is {1=1}
    lRUCache.put(2, 2); // cache is {1=1, 2=2}
    lRUCache.get(1);    // return 1
    lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
    lRUCache.get(2);    // returns -1 (not found)
    lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
    lRUCache.get(1);    // return -1 (not found)
    lRUCache.get(3);    // return 3
    lRUCache.get(4);    // return 4
 */
public class LRUCache
{
    private int counter = -1;
    private KeyValuePair<int, int> LRU;
    Dictionary<int, int> d = new Dictionary<int, int>();
    private Stack<int> LRUindexes = new();
    KeyValuePair<int, int>[] arr;
    public LRUCache(int capacity)
    {
        arr = new KeyValuePair<int, int>[capacity];
        //throw new NotImplementedException();
    }

    public int Get(int key)
    {
        return 0;
        //throw new NotImplementedException();
    }

    public void Put(int key, int value)
    {
        if (counter == -1)
        {
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key, value);
            arr[++counter] = kvp;
            LRU = kvp;
            LRUindexes.Push(counter);
        }
        else
        {
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key, value);
            if (counter + 1 == arr.Length)
            {
                if (!LRUindexes.TryPop(out int index)) throw new Exception("NO KEYS WERE ADDED");
                arr[index] = kvp;
            }
            else
            {
                arr[++counter] = kvp;
                LRU = kvp;
                LRUindexes.Push(counter);    
            }
            
        }
        //throw new NotImplementedException();
    }
}
