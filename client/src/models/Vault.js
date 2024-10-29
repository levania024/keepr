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
        this.creator = new Profile(data.creator)
    }
}

// const data =
// {
//     "id": 338,
//     "createdAt": "2024-10-29T03:13:59",
//     "updatedAt": "2024-10-29T03:13:59",
//     "name": "Stuff I like",
//     "description": "Can't live without these",
//     "img": "https://images.unsplash.com/photo-1595173425119-1c54835c1874?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
//     "isPrivate": false,
//     "creatorId": "66f6096177b4c669cf23e6e3",
//     "creator": {
//         "id": "66f6096177b4c669cf23e6e3",
//         "name": "Lucy",
//         "picture": "https://images.unsplash.com/photo-1523586044048-b7d32d5da502?w=200&h=200&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGxpemFyZHxlbnwwfHwwfHx8MA%3D%3D",
//         "coverImg": "https://images.unsplash.com/photo-1602298674761-700e96568f5f?w=1080&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mzh8fGp1bmdsZXxlbnwwfDB8MHx8fDA%3D",
//         "createdAt": "2024-10-25T16:38:06",
//         "updatedAt": "2024-10-28T22:54:20"
//     }
// }