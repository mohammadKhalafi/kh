using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class C
    {
        private readonly List<string> _list;
        private readonly HashSet<string> _hashSet;

        public C()
        {
            _list = new List<string>();
            
            foreach(var i in Enumerable.Range(0, 100000))
            {
                _list.Add(i.ToString());
            }
            
            _hashSet = new HashSet<string>();
            
            foreach(var i in Enumerable.Range(0, 100000))
            {
                _hashSet.Add(i.ToString());
            }
        }
        
        ///intersect two enumerables in order n ^ 2
        [Benchmark]
        public void ON2()
        {
            _hashSet.Where(x => _list.Contains(x)).ToList();
        }
        
        //intersect two enumerables in order n
        [Benchmark]
        public void ON()
        {
            _list.Where(x => _hashSet.Contains(x)).ToList();
        }
    }
}
