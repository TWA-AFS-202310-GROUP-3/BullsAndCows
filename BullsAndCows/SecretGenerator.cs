using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class SecretGenerator
    {

        public virtual string GenerateSecret()
        {
            var random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 4)
            {
                numbers.Add(random.Next(0, 9));
            }

            return string.Join(string.Empty, numbers.ToArray());
        }
    }
}