import { RootStore } from "./RootStore";
import { observable, action, runInAction, computed } from "mobx";
import { ICoaches } from "../Models/Coaches/ICoaches";
import Agent from "../API/Agent";
import { IMessageCoach } from "../Models/Coaches/IMessageCoach";
import { toast } from "react-toastify";
import { IDetailedCoach } from "../Models/Coaches/IDetailedCoach";
import { history } from "../..";

export class CoachesStore {

    rootStore : RootStore;

    @observable coaches : ICoaches[] = [];
    @observable coach : IDetailedCoach | null = null;

    @computed get activeCoaches() {
        return this.coaches.filter(x => x.isActive === true);
    }

    @computed get archivedCoaches() {
        return this.coaches.filter(x => x.isActive === false);
    }

    constructor (root: RootStore) {
        this.rootStore = root;
    }

    @action loadCoaches = async (active: boolean) => {
        try {
            var apiData = await Agent.Coaches.list(active);
            runInAction("Setting coaches", () => {
                this.coaches = apiData;
            });

            return apiData;
        } catch (error) {
            console.log(error);
        }
    }

    @action loadCoach = async(id : string) => {
        try {
            var data = await Agent.Coaches.loadCoach(id);
            
            runInAction("Setting coach", () => {
                this.coach = data;
            });

            return data;

        } catch(error) {
            console.log(error);
        }
    }

    @action messageCoach = async (values: IMessageCoach) => {
        try {
            await Agent.Coaches.messageCoach(values);
            toast("Message sent");
        } catch (error) {
            console.log(error);
        }
    }

    @action archiveCoach = async (id: string) => {
        try {
            await Agent.Coaches.archive(id);
            toast("Successfully archived");
        } catch (error) {
            console.log(error);
        }
    }

    @action activateCoach = async (id: string) => {
        try {
            await Agent.Coaches.activate(id);
            toast("Successfully reactivated");
        } catch (error) {
            console.log(error);
        }
    }

    @action editCoach = async (values : IDetailedCoach) =>{
        try {
            await Agent.Coaches.edit(values);
            toast("Successfully edited coach");
            history.push("/coaches");
        } catch(error) {
            console.log(error);
        }
        
    }

    @action createCoach = async (values: IDetailedCoach) => {
        await Agent.Coaches.create(values);
        toast("Successfully created coach");
    }

    @action listAvailableStudents = async (id: string) => {
        
    }
}