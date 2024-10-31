import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { Vault } from "@/models/Vault.js";

class VaultsService
{
    async deleteVault(vaultId) {
       const response = await api.delete(`api/vaults/${vaultId}`);
       logger.log('delete vault', response.data)
       const vaultToDelete = AppState.vaults.findIndex((vault) => vault.id == vaultId)
       AppState.vaults.splice(vaultToDelete,1)
    }

    async updateVault(vaultId, vaultData) {
      const response = await api.put(`api/vaults/${vaultId}`,vaultData)
      logger.log('update vault ', response.data)
      const newVault = new Vault(response.data)
      AppState.vaults.push(newVault)
    }

    async getMyVault() {
      const response = await api.get('account/vaults')
      logger.log('get my vaults', response.data)
      AppState.vaults = response.data.map(vault => new Vault(vault))
    }

    async getUserVault(profileId) {
      AppState.vaults = null
      const response = await api.get(`api/profiles/${profileId}/vaults`)
      logger.log('get user vaults', response.data)
      AppState.vaults = response.data.map(vault => new Vault(vault))
    }

    async getVaultById(vaultId) 
    {
      AppState.vault = null
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