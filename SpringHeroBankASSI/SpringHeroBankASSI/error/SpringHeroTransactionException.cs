using System;

namespace SpringHeroBankASSI.error
{
    public class SpringHeroTransactionException: Exception
    {
        public SpringHeroTransactionException(string message) : base(message)
        {
            
        }
    }
}