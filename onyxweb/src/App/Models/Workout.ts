export interface Workout {
    dateOfWorkout : Date,
    id: string,
    name: string,
    description: string,
    exercises : Exercise[]
}

export interface Exercise {
    id: string,
    description: string,
    name: string,
    pace : string,
    reps: number,
    sets: number,
    weight? : number
}