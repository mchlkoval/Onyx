import { RootStore } from "./RootStore";
import { action, observable, runInAction } from "mobx";
import Agent from "../API/Agent";
import { Athletes } from "../Models/Athlete/Athletes";

export class AthleteStore {

    rootStore : RootStore;

    @observable athletes : Athletes[] = [];

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action listAthletes = async (active: boolean) => {
        try {
            const apiResult = await Agent.Athlete.list(active);

            runInAction(() => {
                this.athletes = apiResult;
            })
        } catch (error) {
            console.log(error);
        }
    }
}