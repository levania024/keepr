namespace keepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault CreateVault(VaultCreationDTO creationData, string creatorId)
    {
        string sql = @"
        INSERT INTO
        vaults ( name,description,img,isPrivate,creatorId)
        VALUES ( @Name, @Description, @Img,@IsPrivate,@creatorId);

        SELECT 
        vaults.*,
        accounts.* 
        FROM vaults
        JOIN accounts ON vaults.creatorId = accounts.id
        WHERE vaults.id = LAST_INSERT_ID();";

        return _db.Query(sql, (Vault v, Profile p) =>
        {
            v.Creator = p;
            return v;
        }, new
        {
            creationData.Name,
            creationData.Img,
            creationData.Description,
            creationData.IsPrivate,
            creatorId

        }).FirstOrDefault();
    }

    internal void DeleteVault(int vaultId)
    {
        string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
        int affectedRows = _db.Execute(sql, new { vaultId });
        if (affectedRows > 1) throw new Exception($"{affectedRows} are affected");
    }

    internal List<Vault> GetMyVault(string userId)
    {
        string sql = @"SELECT 
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON vaults.creatorId = accounts.id
        WHERE vaults.creatorId = @UserId;";

        List<Vault> vaults = _db.Query(sql, (Vault v, Profile p) =>
        {
            v.CreatorId = v.CreatorId;
            v.Creator = p;
            return v;
        }, new { userId }).ToList();
        return vaults;
    }

    internal List<Vault> GetUserVault(string profileId)
    {
        string sql = @"
        SELECT 
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts on vaults.creatorId = accounts.id
        WHERE vaults.creatorId = @profileId;";

        List<Vault> vaults = _db.Query(sql, (Vault k, Profile p) =>
        {
            k.Creator = p;
            return k;
        }, new { profileId }).ToList();
        return vaults;
    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT *
        FROM vaults
        JOIN accounts on accounts.id = vaults.creatorId
        WHERE vaults.id = @vaultId;";

        return _db.Query(sql, (Vault v, Profile p) =>
         {
             v.Creator = p;
             return v;
         }, new
         {
             vaultId
         }).FirstOrDefault();
    }

    internal void UpdateVault(Vault vault)
    {
        string sql = @"
        UPDATE vaults 
        SET
        name = @Name,
        isPrivate = @IsPrivate
        WHERE
        id = @Id
        LIMIT 1;";

        int affectedRows = _db.Execute(sql, vault);
        if (affectedRows > 1) throw new Exception($"{affectedRows} are affected");
    }
}