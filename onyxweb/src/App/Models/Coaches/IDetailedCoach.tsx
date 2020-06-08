import { GenderType } from "../Enums/Gender";

export interface IDetailedCoach {
    id: string,
    name: string,
    gender: GenderType,
    dateHired: Date,
    dateOfBirth : Date,
    assignedAthletes : IAssignedAthletes[]
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
    gender: GenderType = GenderType.Female;
    dateHired: Date = new Date();
    dateOfBirth: Date = new Date();
    assignedAthletes: IAssignedAthletes[] =
    [{
        athleteId: "",
        name: "",
        dateJoined: new Date(),
        gender: GenderType.Female
    }];

    constructor(init? : IDetailedCoach) {
        Object.assign(this, init);
    }
}
