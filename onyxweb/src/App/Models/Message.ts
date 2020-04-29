export interface Message {
    id: string,
    from: string,
    dateOfMessage: Date,
    content: string,
    isDeleted: boolean
}