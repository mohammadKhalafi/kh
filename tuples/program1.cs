using System;
using System.Collections.Generic;
using System.Diagnostics;

PrintExecuteTime(TestObj);
PrintExecuteTime(TestTuple);


void PrintExecuteTime(Action action)
{
    var stopWatch = Stopwatch.StartNew();

    action.Invoke();

    stopWatch.Stop();
    Console.WriteLine($"{stopWatch.ElapsedMilliseconds} {stopWatch.ElapsedTicks}");
}


void TestTuple()
{
    var result = ReturnTuple();
}
(List<string> NewRequestItems, Dictionary<long, long> Mapping) ReturnTuple()
{
    var list = new List<string> {"dds"};
    var dict = new Dictionary<long, long> {{1, 2}};
    return (list, dict);
}


void TestObj()
{
    var result = ReturnObj();
}
Result ReturnObj()
{
    var list = new List<string> {"dds"};
    var dict = new Dictionary<long, long> {{1, 2}};
    
    var result = new Result(){myList = list, myDict = dict};

    return result;
}


class Result
{
    public List<string> myList { set; get; }
    public Dictionary<long, long> myDict { set; get; }
}
