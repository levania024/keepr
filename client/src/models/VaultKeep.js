import { Profile } from "./Profile.js"

export class VaultKeep{
    constructor(data){
        this.id = data.id
        this.keepId = data.keepId
        this.vaultId = data.vaultId
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.creator = data.creator ? new Profile(data.creator) : null
    }
}