namespace keepr.Services;
public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  private Account GetAccount(string accountId)
  {
    Account account = _repo.GetById(accountId);
    if (account == null)
    {
      throw new Exception("Invalid Account Id");
    }
    return account;
  }

  internal Account GetOrCreateAccount(Account userInfo)
  {
    Account account = _repo.GetById(userInfo.Id);
    if (account == null)
    {
      return _repo.Create(userInfo);
    }
    return account;
  }

  internal Account Edit(Account editData, string accountId)
  {
    Account original = GetAccount(accountId);
    original.Name = editData.Name ?? editData.Name;
    original.Picture = editData.Picture ?? editData.Picture;
    return _repo.Edit(original);
  }

    internal Profile EditAccount(string accountId, Account accountData)
    {
      Profile profile = GetAccount(accountId);

      if(profile.Id != accountId) throw new Exception();
      profile.Name = accountData.Name ?? profile.Name;
      profile.Picture = accountData.Picture ?? profile.Picture;
      profile.CoverImg = accountData.CoverImg ?? profile.CoverImg;

      return _repo.EditAccount(profile);
    }
}
