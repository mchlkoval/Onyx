import { configure } from 'mobx'
import UserStore from './UserStore';
import CommonStore from './CommonStore';
import ModalStore from './ModalStore';
import { createContext } from 'react';


configure({enforceActions: 'always'});

export class RootStore {
    userStore : UserStore;
    commonStore: CommonStore;
    modalStore: ModalStore;

    constructor() {
        this.userStore = new UserStore(this);
        this.commonStore = new CommonStore(this);
        this.modalStore = new ModalStore(this);
    }
}

export const RootStoreContext = createContext(new RootStore());