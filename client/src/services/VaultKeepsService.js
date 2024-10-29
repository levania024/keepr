import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService{
    async createVaultKeep(vaultKeepData) {
        const response = await api.post('api/vaultKeeps', vaultKeepData)
        logger.log('create a vault keep ', response.data)
    }

}

export const vaultKeepsService = new VaultKeepsService();