import { createContext } from "react";
import { observable, action, runInAction } from "mobx";
import { Membership} from "../Models/Memberships/Membership";
import Agent from "../API/Agent";
import { RootStore } from "./RootStore";
import { IDetailedMembership } from "../Models/Memberships/IDetailedMembership";

export class MembershipStore {

    rootStore : RootStore;

    @observable memberships : Membership[] = [];
    @observable detailedMembership: IDetailedMembership | null = null;

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action loadMemberships = async () => {
        try {
            const apiResult = await Agent.Memberships.list();
            
            runInAction("Getting Memberships from API", () => {
                console.log("data from membership: ", apiResult);
                this.memberships = apiResult;
                console.log(this.memberships);
            })

        } catch (error) {
            console.log("Error loading messages");
        }
    }

    @action loadVerboseMembership = async (membershipId: string) => {
        try {
            const apiResult = await Agent.Memberships.detailed(membershipId);
            runInAction("Getting Verbose Memberships from API", () => {
                this.detailedMembership = apiResult;
            })
            
            return apiResult;
        } catch (error) {
            console.log("Error loading messages");
        }
    }
}