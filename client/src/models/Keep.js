import { Profile } from "./Profile.js"

export class Keep{
    constructor(data){
        this.id = data.id
        this.kept = data.kept
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.creator = data.creator ? new Profile(data.creator) : null
    }
}
