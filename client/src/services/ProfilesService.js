import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Profile } from "@/models/Profile.js"

class ProfilesService{
    async getUserProfile(profileId) {
        AppState.profiles = null
        const response = await api.get(`api/profiles/${profileId}`)
        logger.log('get user profile', response.data)
        AppState.profiles = new Profile(response.data)
    }
}

export const profilesService = new ProfilesService()