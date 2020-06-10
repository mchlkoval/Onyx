import { GenderType } from "../Enums/Gender";

export interface IDetailedCoach {
    id: string,
    name: string,
    email: string,
    city: string,
    state: string,
    country: string,
    address: string,
    address2: string,
    gender: GenderType,
    dateHired: Date,
    dateOfBirth : Date,
    assignedAthletes: IAssignedAthletes[] | null
}

interface IAssignedAthletes {
    athleteId : string,
    gender: GenderType,
    dateJoined: Date,
    name: string
}

export class DetailedCoach implements IDetailedCoach {
    id: string = "";
    name: string = "";
    email: string = "";
    city: string = "";
    state: string = "";
    country: string = "";
    address: string = "";
    address2: string = "";
    gender: GenderType = GenderType.Female;
    dateHired: Date = new Date();
    dateOfBirth: Date = new Date();
    assignedAthletes: IAssignedAthletes[] | null = null;

    constructor(init? : IDetailedCoach) {
        Object.assign(this, init);
    }
}
