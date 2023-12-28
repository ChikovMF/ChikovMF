namespace ChikovMF.Persistence;

public class DbInitializer
{
    public static void Initialize(ChikovMFDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
