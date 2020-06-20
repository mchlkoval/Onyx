import { GenderType } from "../Enums/Gender";
import { UserType } from "../Enums/UserType";

export interface IDetailedAthlete {
    id : string,
    name: string,
    gender: GenderType,
    city: string,
    state: string,
    country: string,
    address : string,
    address2 : string,
    weight: number,
    age: number,
    dateOfBirth: Date,
    assignedCoaches: IAssignedCoach[] | null
}

export interface IAssignedCoach {
    id: string,
    name: string,
    gender: GenderType
}

export class DetailedAthlete implements IDetailedAthlete {
    id: string = "";
    name: string = "";
    gender: GenderType = GenderType.Female;
    city: string = "";
    state: string = "";
    country: string = "";
    address: string = "";
    address2: string = "";
    weight: number = 150;
    age: number = 18;
    dateOfBirth: Date = new Date();
    assignedCoaches: IAssignedCoach[] | null = null;

    constructor(init? : IDetailedAthlete) {
        Object.assign(this, init);
    }
}