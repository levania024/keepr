import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { Keep } from "@/models/Keep.js";

class KeepsService
{
  async getMyKeeps(accountId) {
    AppState.keeps = null
    const response = await api.get(`api/profiles/${accountId}/keeps`)
    logger.log('get user keeps', response.data)
    AppState.keeps = response.data.map(keep => new Keep(keep))
  }

  async getKeepById(keepId) {
    AppState.activeKeep = null
      const response = await api.get(`api/keeps/${keepId}`)
      logger.log('get keep by id', response.data)
      AppState.activeKeep = new Keep(response.data)
  }
  
  async getPublicKeepById(vaultId) {
    AppState.keeps = null
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('get public keep by id', response.data)
    AppState.keeps = response.data.map(keep => new Keep(keep))
  }

  async getUserKeep(profileId) {
    AppState.keeps = null
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('get user keeps', response.data)
    AppState.keeps = response.data.map(keep => new Keep(keep))
  }

  async deleteKeep(keepId)
  {
    const response = await api.delete(`api/keeps/${keepId}`)
    logger.log('delete keep', response.data)
    const keepToDelete = AppState.keeps.findIndex(keep => keep.id == keepId)
    AppState.keeps.splice(keepToDelete,1)
  }

  setKeep(keepProp) 
  {
    AppState.activeKeep = keepProp
    
    return
  }
  
  async createKeep(keepData) 
  {
    const response = await api.post("api/keeps", keepData)
    logger.log('create keep', response.data)
    const newKeep = new Keep(response.data)

    if(AppState.profiles?.id == newKeep.creatorId)
    AppState.keeps.push(newKeep)
  }

  async getAllKeep() 
  {
   const response = await api.get("api/keeps")
   logger.log("get all keeps", response.data)
   AppState.keeps = response.data.map(keep => new Keep(keep))
  }
}

export const keepsService = new KeepsService();