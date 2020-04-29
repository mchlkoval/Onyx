import { RootStore } from "./RootStore";
import { observable, action } from "mobx";
import { ExerciseGroup } from "../Models/Workout";

export default class WorkoutStore {

    rootStore : RootStore;

    @observable exerciseGroups: ExerciseGroup[] = [];
    @observable exerciseGroup: ExerciseGroup | null = null;

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action getExerciseGroups = async () => {
        
    }

}


