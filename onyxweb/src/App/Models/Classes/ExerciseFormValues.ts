import { Exercise } from "../Workout";

interface IPartialExerciseValues extends Partial<Exercise> {

}

export class ExerciseFormValues implements IPartialExerciseValues {
    id?: string = undefined;
    description: string = "";
    name: string = ""; 
    pace: string = "";
    reps: number = 5;
    sets: number = 10;
    weight?: number | undefined;

    constructor(init? : Exercise) {
        Object.assign(this, init);
    }
}