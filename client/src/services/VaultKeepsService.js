import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { VaultKeep } from "@/models/VaultKeep.js";
import { AppState } from "@/AppState.js";

class VaultKeepsService{
    
    async createVaultKeep(vaultKeepData)
    {
        const response = await api.post('/api/vaultkeeps', vaultKeepData)
        logger.log('create a vault keep ', response.data)
        const newVaultKeep = new VaultKeep(response.data)

        if(AppState.activeKeep.id == newVaultKeep.keepId){
            AppState.vaultKeeps.push(newVaultKeep)
        }

        const vaultKeepKeep = AppState.keeps.find(keep => keep.id == newVaultKeep.keepId)
        if(vaultKeepKeep){
            vaultKeepKeep.kept++
        }

        AppState.myVaultKeep.push(newVaultKeep)
    }
}

export const vaultKeepsService = new VaultKeepsService();