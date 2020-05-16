import { RootStore } from "./RootStore";
import { observable, action, runInAction, computed } from "mobx";
import { Exercise, Workout } from "../Models/Workout";
import Agent from "../API/Agent";

export default class WorkoutStore {

    rootStore : RootStore;

    @observable exercises: Exercise[] = [];
    @observable exercise: Exercise | null = null;
    
    @observable workouts: Workout[] = [];
    @observable workout : Workout | null = null;

    @computed get exercisesForForm() {
        const data = this.exercises.map((e) => ({
                name: e.name,
                id: e.id,
                sets: e.sets,
                reps: e.reps,
                weight: e.weight                                  
        }));
        
        console.log("Data: ", data);
        return data;
    }

    @computed get events() {
        const data =  this.workouts.map((w) => ({
            id: w.id,
            title: w.name,
            date: w.dateOfWorkout
        }))

        console.log("Data: ", data);
        return data;
    };

    constructor(root: RootStore) {
        this.rootStore = root;
    }

    @action getExercises = async (workoutId: string, isoDateString: string) => {
        
        try {
            const data = await Agent.Workouts.listExercises(workoutId, isoDateString);
            runInAction('setting exercise', () => {
                this.exercises = data
            });
            
        } catch(error) {
            console.log(error);
        }

    }

    @action getWorkouts = async () => {
        try {
             const data = await Agent.Workouts.listWorkouts();
             
             runInAction('setting workouts', () => {
                 this.workouts = data;
             })

        } catch (error) {
            console.log(error);
        }
    }

    @action createExercise = async(data: Exercise) => {

    }

    @action editExercise = async (data: Exercise) => {

    }
}


