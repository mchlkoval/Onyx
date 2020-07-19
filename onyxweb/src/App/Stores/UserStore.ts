import { RootStore } from "./RootStore";
import { runInAction, action, observable, computed } from "mobx";
import { history } from "../..";
import { IUserFormValues, IUser } from "../Models/User";
import Agent from "../API/Agent";

export default class UserStore {

    rootStore: RootStore;

    @observable user: IUser | null = null;

    @computed get isLoggedIn() {
        return !!this.user;
    }

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action login = async (values: IUserFormValues) => {
        try {
            const user = await Agent.User.login(values);
            console.log("User values: ", user);
            runInAction('Setting user login', () => { 
                this.user = user; 
            });  
            this.rootStore.commonStore.setToken(user.token);
            this.rootStore.modalStore.closeModal();
            
            history.push('/overview')

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

            history.push('/overview');
        } catch(error) {
            throw error;
        }
    }

    @action setUser = async () => {
        try {
            const user = await Agent.User.current();
            console.log("current user: ", user)
            runInAction(() => {
                this.user = user;
            })
        } catch (error) {
            throw error;
        }
    }
}