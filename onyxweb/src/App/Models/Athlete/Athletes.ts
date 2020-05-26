import { GenderType } from "../Enums/Gender";

export interface Athletes {
    id: string,
    name: string,
    gender: GenderType,
    isActive: boolean,
    dateJoined: Date,
    dateArchived?: Date
}