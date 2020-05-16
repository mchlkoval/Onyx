import { configure } from 'mobx'
import UserStore from './UserStore';
import CommonStore from './CommonStore';
import ModalStore from './ModalStore';
import { createContext } from 'react';
import WorkoutStore from './WorkoutStore';
import { MembershipStore } from './MembershipStore';


configure({enforceActions: 'always'});

export class RootStore {
    userStore : UserStore;
    commonStore: CommonStore;
    modalStore: ModalStore;
    workoutStore: WorkoutStore;
    membershipStore: MembershipStore;

    constructor() {
        this.userStore = new UserStore(this);
        this.commonStore = new CommonStore(this);
        this.modalStore = new ModalStore(this);
        this.workoutStore = new WorkoutStore(this);
        this.membershipStore = new MembershipStore(this);
        
    }
}

export const RootStoreContext = createContext(new RootStore());