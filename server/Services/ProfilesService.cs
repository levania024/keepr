
namespace keepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _profilesRepository;

    public ProfilesService(ProfilesRepository profilesRepository)
    {
        _profilesRepository = profilesRepository;
    }

    internal Profile GetUserProfile(string profileId)
    {
        Profile profile = _profilesRepository.GetUserProfile(profileId);

        return profile;
    }
}
