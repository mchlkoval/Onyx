import { createContext } from "react";
import { observable, action, runInAction } from "mobx";
import { Membership, VerboseMembership } from "../Models/Membership";
import Agent from "../API/Agent";

export class MembershipShore {

    @observable memberships : Membership[] = [];
    @observable membership : Membership |  null = null;

    @observable verboseMemberships : VerboseMembership[] = [];
    @observable verboseMembership : VerboseMembership | null = null;


    @action loadMemberships = async () => {
        try {
            const apiResult = await Agent.Memberships.list();
            
            runInAction("Getting Memberships from API", () => {
                this.memberships = apiResult;
            })

        } catch (error) {
            console.log("Error loading messages");
        }
    }

    @action loadVerboseMemberships = async () => {
        try {
            const apiResult = await Agent.Memberships.verboseList();
            runInAction("Getting Verbose Memberships from API", () => {
                this.verboseMemberships = apiResult;
            })
            
        } catch (error) {
            console.log("Error loading messages");
        }
    }

    @action setVerboseMembership = async (membershipId : string) => {
        const toSet = this.verboseMemberships.filter(member => member.id === membershipId)[0];
        this.verboseMembership = toSet;
    }

}

export const MembershipShoreContext = createContext(new MembershipShore());