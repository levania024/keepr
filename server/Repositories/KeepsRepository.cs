namespace keepr.Repositories;
public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep CreateKeep(KeepCreationDTO creationData, string creatorId)
    {
        string sql = @"
       INSERT INTO keeps(name,description,img,creatorId)
       VALUES(@Name,@Description,@Img,@creatorId);

        SELECT 
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts on keeps.creatorId = accounts.id
        WHERE keeps.id = LAST_INSERT_ID();";

        return _db.Query(sql, (Keep k, Profile p) =>
        {
            k.Creator = p;
            return k;
        }, new
        {
            creationData.Name,
            creationData.Description,
            creationData.Img,
            creatorId

        }).FirstOrDefault();

    }

    internal void DeleteKeep(int keepId)
    {
        string sql = @"DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

        int affectedRows = _db.Execute(sql, new { keepId });
        if (affectedRows > 1) throw new Exception($"{affectedRows} are affected");
    }

    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
        SELECT 
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts on keeps.creatorId = accounts.id;";

        List<Keep> keeps = _db.Query(sql, (Keep k, Profile p) =>
        {
            k.Creator = p;
            return k;
        }).ToList();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        string sql = @"
        UPDATE keeps SET views = views + 1 WHERE keeps.id = @keepId;
       SELECT * FROM keeps 
       JOIN accounts on accounts.id = keeps.`creatorId`
       WHERE keeps.id = @keepId;";

        Keep keep = _db.Query(sql, (Keep k, Profile p) =>
        {
            k.Creator = p;
            return k;
        }, new { keepId }).FirstOrDefault();

        return keep;
    }


    internal List<VaultKeepKeeps> GetKeepsInVault(int vaultId)
    {
        string sql = @"
        SELECT 
        keeps.*,
        vaultKeeps.*,
        accounts.*
        FROM vaultKeeps
        Join keeps ON keeps.id = vaultKeeps.keepId
        Join accounts ON keeps.creatorId = accounts.id;";

        List<VaultKeepKeeps> keep = _db.Query(sql, (VaultKeepKeeps k, VaultKeepKeeps vK, Profile p) =>
        {
            k.Creator = p;
            k.VaultKeepId = vK.Id;
            

            return k;
        }, new { vaultId }).ToList();
        return keep;
    }

    internal List<Keep> GetUserKeep(string profileId)
    {
        string sql = @"
        SELECT 
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts on keeps.creatorId = accounts.id
        WHERE keeps.creatorId = @profileId;";

        List<Keep> keeps = _db.Query(sql, (Keep k, Profile p) =>
        {
            k.Creator = p;
            
            return k;
        }, new{profileId}).ToList();
        return keeps;
    }

    internal void UpdateKeep(Keep keep)
    {
        string sql = @"
        UPDATE keeps SET 
        name = @Name, 
        description = @Description
        WHERE id = @Id 
        LIMIT 1;";

        int affectedRows = _db.Execute(sql, keep);
        if (affectedRows > 1) throw new Exception($"{affectedRows} are affected");

    }
}

