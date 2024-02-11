namespace ChikovMF.Application.Common.Exceptions
{
    public class SaveChangesInContextException : Exception
    {
        public SaveChangesInContextException() : base("An error occurred while saving changes to the context") { }
    }
}
