export interface Workout {
    dateOfWorkout : Date,
    id: string,
    name: string,
    description: string,
    exerciseGroups : ExerciseGroup[]
}

export interface ExerciseGroup {
    id: string,
    name: string,
    workoutId: string,
    sets: number,
    exercises: Exercise[]
}

export interface Exercise {
    id: string,
    description: string,
    name: string,
    pace : string,
    reps: number,
    weight? : number
}