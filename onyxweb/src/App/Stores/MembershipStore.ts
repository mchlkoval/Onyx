import { createContext } from "react";
import { observable, action, runInAction } from "mobx";
import { Membership } from "../Models/Membership";
import Agent from "../API/Agent";

export class MembershipShore {

    @observable memberships : Membership[] = [];
    @observable membership : Membership | null = null;

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

}

export const MembershipShoreContext = createContext(new MembershipShore());