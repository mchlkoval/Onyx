import { ITeamMembers } from "./ITeams";

export interface IDetailedTeam {
    id: string,
    name: string,
    isActive: boolean,
    creationDate: Date,
    archiveDate: Date | null,
    athletes : ITeamMembers[] ,
    coaches: ITeamMembers[] 

}

export class DetailedTeam implements IDetailedTeam {
    id: string = "";
    name: string = "";
    isActive: boolean = true;
    creationDate: Date = new Date();
    archiveDate: Date | null = null;
    athletes: ITeamMembers[] = [];
    coaches: ITeamMembers[] = [];

    /**
     *
     */
    constructor(init? : IDetailedTeam) {   
        Object.assign(this, init);
    }

}