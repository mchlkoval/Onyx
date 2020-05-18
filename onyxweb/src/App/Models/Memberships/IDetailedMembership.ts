export interface IDetailedMembership {
    id: string,
    name: string,
    description: string,
    cost: number,
    startDate: Date,
    endDate: Date,
    workouts: {
        id: string,
        name: string,
        description: string,
        dateOfWorkout: Date,
        minSets: number,
        minReps: number,
        minWeight: number | undefined,
        exercises: [{
            id: string
            description: string,
            name: string
        }]
    }[]
} 


export class DetailedMembership implements IDetailedMembership {
    id: string = "";
    name: string = "";
    description: string = "";
    cost: number = 0;
    startDate: Date = new Date();
    endDate: Date = new Date();
    workouts: {
        id: string,
        name: string;
        description: string;
        dateOfWorkout: Date;
        minSets: number;
        minReps: number;
        minWeight: number | undefined;
        exercises: [{
            id: string,
            description: string;
            name: string;
        }];
    }[] = [{id: "", name: "", description: "", dateOfWorkout: new Date(), minSets: 0, minReps: 0, minWeight: 0, exercises: [{description: "", name: "", id: ""}]}];
    

    constructor(init? : IDetailedMembership) { 

        Object.assign(this, init);
    }
}