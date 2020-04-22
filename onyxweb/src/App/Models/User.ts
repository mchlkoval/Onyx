import { UserType } from "./Enums/UserType";

export interface IUser {
    userName: string,
    token: string,
    userType: UserType,
    email: string
}

export interface IUserFormValues {
    email?: string,
    userType?: UserType,
    password: string,
    userName: string,
}