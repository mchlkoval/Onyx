import Agent from "../API/Agent";
import { observable, action, runInAction } from "mobx";
import { Message } from "../Models/Message";
import { RootStore } from "./RootStore";


export class MessageStore {

    rootStore : RootStore;

    @observable messages : Message[] = [];
    @observable message: Message | null = null;

    constructor (root: RootStore) {
        this.rootStore = root;
    }

    //TODO: Add some sort of observable to track if we are loading something or submitting.
    @action loadMessages = async () => {
        try {
            const apiResult = await Agent.Messages.list();

            runInAction("Setting messages map", () => {
                this.messages = apiResult;
            })

            return apiResult;

        } catch (error) {
            console.log("Error loading messages");
        }
    }
}