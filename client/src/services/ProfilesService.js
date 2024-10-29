import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Account } from "@/models/Account.js"

class ProfilesService{
    async getUserProfile(profileId) {
        const response = await api.get(`api/profiles/${profileId}`)
        logger.log('get user profile', response.data)
        AppState.account = new Account(response.data)
    }
}

export const profilesService = new ProfilesService()