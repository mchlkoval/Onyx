import { GenderType } from "../Enums/Gender";
import { UserType } from "../Enums/UserType";

export interface IDetailedAthlete {
    id : string,
    name: string,
    gender: GenderType,
    userType: UserType,
    city: string,
    state: string,
    country: string,
    address : string,
    address2 : string,
    weight: number,
    age: number,
    dateOfBirth: Date
}

export class DetailedAthlete implements IDetailedAthlete {
    id: string = "";
    name: string = "";
    gender: GenderType = GenderType.Female;
    userType: UserType = UserType.Athelete;
    city: string = "";
    state: string = "";
    country: string = "";
    address: string = "";
    address2: string = "";
    weight: number = 150;
    age: number = 18;
    dateOfBirth: Date = new Date();

    constructor(init? : IDetailedAthlete) {
        Object.assign(this, init);
    }
}