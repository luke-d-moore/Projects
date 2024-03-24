using System.Collections.Generic;

namespace FindPrimeNumbers.Interfaces
{
    public interface IMultipleRemover
    {
        List<int> RemoveMultiples(List<int> NumberList, int Factor);
    }
}
