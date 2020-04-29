import Agent from "../API/Agent";
import { observable, action, runInAction } from "mobx";
import { Message } from "../Models/Message";
import { createContext } from "react";


export class MessageStore {

    @observable messages : Message[] = [];
    @observable message: Message | null = null;

    //TODO: Add some sort of observable to track if we are loading something or submitting.
    @action loadMessages = async () => {
        try {
            const apiResult = await Agent.Messages.list();

            runInAction("Setting messages map", () => {
                this.messages = apiResult;
            })

        } catch (error) {
            console.log("Error loading messages");
        }
    }
}

export const MessageStoreContext = createContext(new MessageStore());