import { Profile } from "./Profile.js"

export class Keep{
    constructor(data){
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.creator = new Profile(data.creator)
    }
}

// const data = {
//     "id": 1,
//     "createdAt": "2024-10-25T17:38:46",
//     "updatedAt": "2024-10-25T17:38:46",
//     "name": "Makes you Wonder",
//     "description": "Before colleges, quilts were only quills. However, some nosey salts are thought of simply as clubs. Some morose cabinets are thought of simply as swisses. As far as we can estimate, some swingeing chiefs are thought of simply as kicks.",
//     "img": "https://images.unsplash.com/photo-1618500299034-abce7ed0e8df?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=565&h=518&q=60",
//     "views": 0,
//     "creatorId": "66f6096177b4c669cf23e6e3",
//     "kept": 0,
//     "creator": {
//         "id": "66f6096177b4c669cf23e6e3",
//         "name": "Zoey",
//         "picture": "https://images.unsplash.com/photo-1574145967029-52f4cd6b7e76?w=200&h=200&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHplYnJhfGVufDB8fDB8fHww",
//         "coverImg": "https://images.unsplash.com/photo-1535940360221-641a69c43bac?w=1080&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8c2F2YW5uYWh8ZW58MHx8MHx8fDA%3D",
//         "createdAt": "2024-10-25T16:38:06",
//         "updatedAt": "2024-10-26T22:47:13"
//     }
// }