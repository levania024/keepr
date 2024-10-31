namespace keepr.Repositories;


public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeepCreationDTO creationData, string creatorId)
    {
        string sql = @"
        INSERT INTO
        vaultKeeps ( vaultId, keepId,creatorId)
        VALUES ( @VaultId, @KeepId,@creatorId);

        SELECT 
        vaultKeeps.*,
        accounts.*
        FROM vaultKeeps
        JOIN accounts ON vaultKeeps.creatorId = accounts.id
        WHERE vaultKeeps.id = LAST_INSERT_ID();";

        return _db.Query(sql, (VaultKeep vk, Profile p) =>
        {
            return vk;
        },
        new
        {
            creationData.KeepId,
            creationData.VaultId,
            creatorId
        }).FirstOrDefault();
    }

    internal void DeleteKeep(int vaultKeepId)
    {
        string sql = @"DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";

        int affectedRows = _db.Execute(sql, new { vaultKeepId });
        if (affectedRows > 1) throw new Exception($"{affectedRows} are affected");
    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        string sql = @"SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";

        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
        return vaultKeep;
    }
}

