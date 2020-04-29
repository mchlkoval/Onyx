import { Workout } from "./Workout";

export interface Membership {
    id: string,
    name: string, 
    description : string
}

export interface VerboseMembership extends Membership {
    cost: number,
    workouts: Workout[]
}