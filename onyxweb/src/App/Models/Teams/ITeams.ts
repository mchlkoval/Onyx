import { GenderType } from "../Enums/Gender";
import { UserType } from "../Enums/UserType";

export interface ITeams {
    id: string,
    name: string,
    creationDate: Date,
    archiveDate: Date
    teamMembers : ITeamMembers[]
}

export interface ITeamMembers {
    id: string,
    name: string,
    gender: GenderType,
}