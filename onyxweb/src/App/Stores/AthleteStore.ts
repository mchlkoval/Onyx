import { RootStore } from "./RootStore";
import { action, observable, runInAction, computed } from "mobx";
import Agent from "../API/Agent";
import { Athletes } from "../Models/Athlete/Athletes";
import { toast } from "react-toastify";
import { IMessageAthlete, IMessageAll } from "../Models/Athlete/MessageAthlete";
import { IDetailedAthlete, IAssignedCoach, DetailedAthlete } from "../Models/Athlete/IDetailedAthlete";
import { history } from "../..";

export class AthleteStore {

    rootStore : RootStore;

    @observable athletes : Athletes[] = [];
    @observable athlete : DetailedAthlete = new DetailedAthlete();
    @observable availableCoaches : IAssignedCoach[] = [];

    @computed get activeAthletes() {
        return this.athletes.filter(x => x.isActive === true);
    }

    @computed get archivedAthletes() {
        return this.athletes.filter(x => x.isActive === false);
    }

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action loadAthlete = async (id: string) => {
        try {
            var apiData = await Agent.Athlete.loadAthlete(id);
            runInAction("Loading Athlete", () => {
                this.athlete = apiData;
            })

            return apiData;
        } catch (error) {
            console.log(error);
        }
    }

    @action messageAthlete = async (values : IMessageAthlete) => {
        try {
            await Agent.Athlete.messageAthlete(values);
            toast("Message sent");
        } catch (error) {
            console.log(error);
        }
    }

    @action messageAllAthletes = async (values: IMessageAll) => {
        try {
            await Agent.Athlete.messageAllAthletes(values);
            toast("Messages sent");
        } catch (error) {
            console.log(error);
        }
    }

    @action archiveAthlete = async (id : string) => {
        try {
            await Agent.Athlete.archive(id);
            
            runInAction(() => {
                this.athletes = this.athletes.filter(x => x.id !== id);
            })

            toast("Successfully archived!");
        } catch (error) {
            toast("Error saving message", {type: "error"})
        }
    }

    @action reactiveAthlete = async (id: string) => {
        try {
            await Agent.Athlete.activate(id);

            runInAction(() => {
                this.athletes = this.athletes.filter(x => x.id !== id);
            })

            toast("Successfully reactivated!");
        } catch (error) {
            console.log(error);
        }
    }

    @action listAthletes = async (active: boolean) => {
        try {
            const apiResult = await Agent.Athlete.list(active);

            runInAction(() => {
                this.athletes = apiResult;
            })

            return apiResult;
        } catch (error) {
            console.log(error);
        }
    }

    @action createAthlete = async (athlete: IDetailedAthlete) => {
        try {
            await Agent.Athlete.create(athlete);
            toast(`Successfully created ${athlete.name}`);
            history.push("/athletes");
        } catch (error) {
            console.log(error);
        }
    }

    @action editAthlete = async (athlete: IDetailedAthlete) => {
        try {
            await Agent.Athlete.edit(athlete);
            toast(`Successfully edited ${athlete.name}`);
            history.push("/athletes");
        } catch (error) {
            console.log(error);
        }
    }

    @action handleAddingAvailableCoach = async (coach : IAssignedCoach) => {
        var indexToRemove = this.availableCoaches.indexOf(coach);
        
        if(indexToRemove !== -1) {
            runInAction("Removing element", () => {  
                this.availableCoaches.splice(indexToRemove, 0);
            })
        }
        
        runInAction("Pushing athletes", () => {
            this.athlete?.assignedCoaches?.push(coach);
        })
    }

    @action listAvailableCoaches = async(athleteId: string) => {
        
        var apiData = await Agent.Athlete.listAvailableCoaches(athleteId);

        if(this.athlete != null) {
            apiData = apiData.filter(x => 
                !this.athlete?.assignedCoaches?.map(z => z.id).some(n => n === x.id)
            );
        }

        runInAction("Setting available athletes", () => {
            this.availableCoaches = apiData;
        })

        return apiData;
    }
}