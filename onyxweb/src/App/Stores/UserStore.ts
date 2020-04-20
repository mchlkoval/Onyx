import { RootStore } from "./RootStore";
import { runInAction, action, observable } from "mobx";
import { history } from "../..";
import { IUserFormValues, IUser } from "../Models/User";
import Agent from "../API/Agent";

export default class UserStore {

    rootStore: RootStore;

    @observable user: IUser | null = null;

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action login = async (values: IUserFormValues) => {
        try {
            const user = await Agent.User.login(values);
            runInAction('Setting user', () => { this.user = user; });  
            this.rootStore.commonStore.setToken(user.token);
            this.rootStore.modalStore.closeModal();
            
            console.log("User From API Is: ", user);

        } catch(error) {
            throw error;
        }
    }

    @action register = async (values : IUserFormValues) => {
        try {
            const user = await Agent.User.register(values);
            runInAction(() => {
                this.rootStore.commonStore.setToken(user.token);
                this.rootStore.modalStore.closeModal();
                this.user = user;
            })

            history.push('/activities');
        } catch(error) {
            throw error;
        }
    }
}