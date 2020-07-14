import { RootStore } from "./RootStore";
import { observable, action, runInAction, computed } from "mobx";
import { ITeams } from "../Models/Teams/ITeams";
import Agent from "../API/Agent";
import { IDetailedTeam } from "../Models/Teams/IDetailedTeam";

export class TeamStore {

    rootStore: RootStore;

    @observable teams: ITeams[] = []
    @observable team : IDetailedTeam | null = null;

    @computed get activeTeams() {
        return this.teams.filter(x => x.archiveDate === null);
    }

    @computed get inactiveTeams() {
        return this.teams.filter(x => x.archiveDate !== null);
    }

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action loadTeams = async (orgId: string) => {
        try {
            var apiData = await Agent.Teams.list(orgId);
            
            runInAction("Loading teams", () => {
                this.teams = apiData;
            });

            return apiData;
        } catch (error) {
            console.log(error);
        }
    }

    @action createTeam = async (values : IDetailedTeam) => {

    }

    @action editTeam = async (values : IDetailedTeam) => {

    }

    @action loadTeam = async (id: string) => {
        try {
            var data = await Agent.Teams.detailed(id);

            runInAction("Setting team", () => {
                this.team = data;
            })
    
            return data;
        } catch (error) {
            console.log(error);
        }
        
    }
}