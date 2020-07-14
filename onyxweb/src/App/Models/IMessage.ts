export interface IMessage {
    //Id of the object we are trying to send the message to
    //Here it would have to be a singular message, or a message to a singular
    //object (like Teams) that contains multiple reciepents. 
    id: string,
    message: string
}