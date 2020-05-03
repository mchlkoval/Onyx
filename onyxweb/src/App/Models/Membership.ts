import { Workout } from "./Workout";

export interface Membership {
    id: string,
    name: string, 
    description : string,
    cost: number,
    workouts: Workout[]
}