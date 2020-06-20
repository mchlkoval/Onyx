import { RootStore } from "./RootStore";
import { observable, action, runInAction, computed } from "mobx";
import { ICoaches } from "../Models/Coaches/ICoaches";
import Agent from "../API/Agent";
import { IMessageCoach } from "../Models/Coaches/IMessageCoach";
import { toast } from "react-toastify";
import { IDetailedCoach, IAssignedAthletes } from "../Models/Coaches/IDetailedCoach";
import { history } from "../..";
import { GenderType } from "../Models/Enums/Gender";

export class CoachesStore {

    rootStore : RootStore;

    @observable coaches : ICoaches[] = [];
    @observable coach : IDetailedCoach | null = null;

    @observable availableAthletes : IAssignedAthletes[] = [];

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

    @action handleAddingAvailableAthlete = async (athlete : IAssignedAthletes) => {
        var indexToRemove = this.availableAthletes.indexOf(athlete);
        
        runInAction("Removing element", () => {  
            this.availableAthletes.splice(indexToRemove, 0);
        })
        
        runInAction("Pushing athletes", () => {
            this.coach?.assignedAthletes?.push(athlete);
        })
    }

    @action listAvailableStudents = async (id: string) => {
        try {
            var apiData = await Agent.Coaches.availableAthletes(id);

            if(this.coach !== null) {
                
                apiData = apiData.filter((x, index) => !this.coach!.assignedAthletes?.some(x => {
                    return JSON.stringify(apiData[index]) === JSON.stringify(x)
                })) 
                
            }
            
            runInAction("Setting available students", () => {
                this.availableAthletes = apiData;
            })

            return apiData;
        } catch (error) {
            console.log(error);
        }
     }
}