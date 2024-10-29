import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { Vault } from "@/models/Vault.js";

class VaultsService
{
    async getUserVault(profileId) {
      const response = await api.get(`api/profiles/${profileId}/vaults`)
      logger.log('get user vaults', response.data)
      AppState.vaults = response.data.map(vault => new Vault(vault))
    }
    async getVaultById(vaultId) 
    {
       const response = await api.get(`api/vaults/${vaultId}`)
       logger.log('get vault by id', response.data)
       AppState.vault = new Vault(response.data);
    }

    async createVault(vaultData)
    {
        const response = await api.post("api/vaults", vaultData)
        logger.log('create vaults', response.data)
        const newVault = new Vault(response.data)
        AppState.vaults.push(newVault)
    }
}

export const vaultsService = new VaultsService();