export interface IDetailedMembership {
    id: string,
    name: string,
    description: string,
    cost: number,
    startDate: Date,
    endDate: Date,
    workouts: [{
        name: string,
        description: string,
        dateOfWorkout: Date,
        minSets: number,
        minReps: number,
        minWeight: number | undefined,
        exercises: [{
            description: string,
            name: string
        }]
    }]
} 


export class DetailedMembership implements IDetailedMembership {
    id: string = "";
    name: string = "";
    description: string = "";
    cost: number = 0;
    startDate: Date = new Date();
    endDate: Date = new Date();
    workouts!: [
        { name: string; 
            description: string; 
            dateOfWorkout: Date; 
            minSets: number; 
            minReps: number; 
            minWeight: number | undefined; 
            exercises: [
            { 
                description: string; 
                name: string; 
            }]; 
        }];
    

    constructor(init? : IDetailedMembership) { 

        Object.assign(this, init);
    }
}