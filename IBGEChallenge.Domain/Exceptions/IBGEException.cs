namespace IBGEChallenge.Domain.Exceptions
{
    public class IBGEException : Exception
    {
        public IBGEException(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new IBGEException(error);
            }
        }
    }
}