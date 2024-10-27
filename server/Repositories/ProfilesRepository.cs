namespace keepr.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetUserProfile(int creatorId)
    {
        string sql = @"SELECT * FROM accounts WHERE accounts.id = @creatorId;";

        return _db.Query(sql, new{creatorId}
       ).FirstOrDefault();
    }
}

