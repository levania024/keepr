import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { Keep } from "@/models/Keep.js";

class KeepsService{

  async createKeep(keepData) 
  {
    const response = await api.post("api/keeps", keepData)
    logger.log('create keep', response.data)
    const newKeep = new Keep(response.data)
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