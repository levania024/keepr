import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";

class VaultsService{
    // async createVault(vaultData) {
    //     const response = await api.post("api/vaults", vaultData)
    //     logger.log('create vaults', response.data)
    //     const newVault = new Keep(response.data)
    //     AppState.keeps.push(newVault)
    // }

}

export const vaultsService = new VaultsService();