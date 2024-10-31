namespace keepr.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetUserProfile(string profileId)
    {
        string sql = @"SELECT * FROM accounts WHERE accounts.id = @profileId;";

        return _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
    }
}

