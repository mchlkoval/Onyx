import { RootStore } from "./RootStore";
import { observable, action } from "mobx";
import { Exercise } from "../Models/Workout";

export default class WorkoutStore {

    rootStore : RootStore;

    @observable exercises: Exercise[] = [];
    @observable exercise: Exercise | null = null;

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action getExerciseGroups = async () => {
        
    }

}


