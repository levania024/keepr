
namespace keepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _profilesRepository;

    public ProfilesService(ProfilesRepository profilesRepository)
    {
        _profilesRepository = profilesRepository;
    }

    internal Profile GetUserProfile(int profileId, string userId)
    {
        Profile profile = _profilesRepository.GetUserProfile(profileId);
        if(profile.Id == userId) throw new Exception("not your profile");

        return profile;
    }
}