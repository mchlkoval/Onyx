export interface IUser {
    userName: string,
    token: string,
    userType: number,
    email: string
}

export interface IUserFormValues {
    email?: string,
    userType?: number,
    password: string,
    userName: string,

}