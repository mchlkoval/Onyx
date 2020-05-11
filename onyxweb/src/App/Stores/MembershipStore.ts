import { createContext } from "react";
import { observable, action, runInAction } from "mobx";
import { Membership} from "../Models/Membership";
import Agent from "../API/Agent";
import { RootStore } from "./RootStore";

export class MembershipStore {

    rootStore : RootStore;

    @observable memberships : Membership[] = [];
    @observable membership : Membership |  null = null;

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

    @action loadVerboseMemberships = async () => {
        try {
            const apiResult = await Agent.Memberships.verboseList();
            runInAction("Getting Verbose Memberships from API", () => {
                this.memberships = apiResult;
            })
            
        } catch (error) {
            console.log("Error loading messages");
        }
    }

    @action setVerboseMembership = async (membershipId : string) => {
        const toSet = this.memberships.filter(member => member.id === membershipId)[0];
        this.membership = toSet;
    }

}