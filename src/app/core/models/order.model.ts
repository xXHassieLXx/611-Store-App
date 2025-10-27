// {
//     "id": 0,
//     "total": 0,
//     "createdAt": "2025-10-01T21:51:50.811Z",
//     "systemUserId": 0,
//     "systemUser": {
//       "id": 0,
//       "email": "string",
//       "password": "string",
//       "firstNaame": "string",
//       "lastName": "string",
//       "orders": [
//         "string"
//       ]
//     }

import { SystemUser } from "./user.model";


export interface Order {
    id: number;
    total: number;
    createdAt: string;
    systemUserId: number;
    user: SystemUser;

}