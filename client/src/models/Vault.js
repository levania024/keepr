import { Profile } from "./Profile.js"

export class Vault{
    constructor(data){
        this.id = data.id
        this.img = data.img
        this.name = data.name
        this.isPrivate = data.isPrivate
        this.description = data.description
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.creator = data.creator ? new Profile(data.creator) : null
    }
}