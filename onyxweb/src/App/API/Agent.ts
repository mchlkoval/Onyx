import axios, { AxiosResponse } from 'axios'
import { IUser, IUserFormValues } from '../Models/User';
import { toast } from 'react-toastify';
import { history } from '../..';
import { Message } from '../Models/Message';
import { Membership } from '../Models/Memberships/Membership';
import { Exercise, Workout } from '../Models/Workout';
import { IDetailedMembership } from '../Models/Memberships/IDetailedMembership';
import { Athletes } from '../Models/Athlete/Athletes';
import { IMessageAthlete, IMessageAll } from '../Models/Athlete/MessageAthlete';
import { IDetailedAthlete, IAssignedCoach } from '../Models/Athlete/IDetailedAthlete';
import { ICoaches } from '../Models/Coaches/ICoaches';
import { IDetailedCoach, IAssignedAthletes } from '../Models/Coaches/IDetailedCoach';
import { IMessageCoach } from '../Models/Coaches/IMessageCoach';
import { ITeams } from '../Models/Teams/ITeams';
import { IDetailedTeam } from '../Models/Teams/IDetailedTeam';

axios.defaults.baseURL = "http://localhost:5000/api"

//#region interceptors
axios.interceptors.request.use((config) => {
    const token = window.localStorage.getItem('jwt');

    if(token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config;
}, error => {
    console.log("Error with the request interceptor", error);
    return Promise.reject(error);
});

axios.interceptors.response.use(undefined, error => {
    if(error.message === "Network Error" && !error.response) {
        toast.error("Network Error - Server Down");
    }

    const {status, data, config} = error.response;
    
    if(status === 404) {
        history.push("/notfound");
    }

    if(status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id')) {
        history.push("/notfound");
    }
    if(status === 500) {
        toast.error("Server Error - Check terminal for more info!");
    }
    
    throw error.response;
}) 
//#endregion

const responseBody = (response: AxiosResponse ) => response.data;

const requests = {
    get : (url: string) => axios.get(url).then(responseBody),
    post : (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put : (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
};

const User = {
    current: () : Promise<IUser> => requests.get('/user'),
    login: (user: IUserFormValues) : Promise<IUser> => requests.post(`/user/login`, user),
    register: (user: IUserFormValues) : Promise<IUser> => requests.post(`/user/register`, user)
}

const Messages = {
    list: (userId: string) : Promise<Message[]> => requests.get(`/message/messages/${userId}`)
}

const Athlete = {
    list: (active : boolean) : Promise<Athletes[]> => requests.get(`/athlete/athletes/${active}`),
    edit: (athlete : IDetailedAthlete) : Promise<any> => requests.put("/athlete/edit", athlete),
    create : (athlete: IDetailedAthlete) : Promise<any> => requests.post("/athlete/create", athlete),
    archive : (id: string) : Promise<any> => requests.put(`/athlete/archive/${id}`, {}),
    activate: (id: string) : Promise<any> => requests.put(`/athlete/reactivate/${id}`, {}),
    messageAthlete : (message: IMessageAthlete) : Promise<any> => requests.post(`/athlete/message`, message),
    messageAllAthletes : (messages: IMessageAll) : Promise<any> => requests.post(`/athlete/message/all`, messages),
    loadAthlete : (id: string) : Promise<IDetailedAthlete> => requests.get(`/athlete/${id}`),
    listAvailableCoaches : (id: string) : Promise<IAssignedCoach[]> =>  {
        if(id !== undefined || id !== "") {
            return requests.get(`/athlete/availableCoaches/${id}`);
        } 

        return requests.get(`/athlete/availableCoaches`);
    }

}

const Coaches = {
    list: (active : boolean) : Promise<ICoaches[]> => requests.get(`/coach/coaches/${active}`),
    loadCoach : (id: string) : Promise<IDetailedCoach> => requests.get(`/coach/detail/${id}`),
    archive: (id: string) : Promise<any> => requests.put(`coach/archive/${id}`, {}),
    activate: (id: string) : Promise<any> => requests.put(`coach/activate/${id}`, {}),
    messageCoach: (message : IMessageCoach) : Promise<any> => requests.post("/coach/message", message),
    messageAll: (message: IMessageAll) : Promise<any> => requests.post("/coach/message/all", message),
    create: (values: IDetailedCoach) : Promise<any> => requests.post("/coach/create", values),
    edit: (values: IDetailedCoach) : Promise<any> => requests.put("/coach/edit", values),
    availableAthletes: (id: string) : Promise<IAssignedAthletes[]> => requests.get(`/coach/availableStudents/${id}`)
}

const Memberships = {
    list : () : Promise<Membership[]> => requests.get("/membership/memberships"),
    detailed : (membershipId: string) => requests.get(`/membership/memberships/${membershipId}`),
    update: (membership: IDetailedMembership) => requests.put("/membership/memberships/update", membership),
    create: (membership: IDetailedMembership) => requests.post("/membership/memberships/create", membership)
}

const Workouts = {
    editExercise: (exercise: Exercise) => requests.post("/workout/create", exercise),
    createExercise: (exercise: Exercise) => requests.put("/workout/update", exercise),
    listWorkouts: (): Promise<Workout[]> => requests.get(`/workout/workouts`),
    listExercises: (workoutId: string, dateRecorded: string) : Promise<Exercise[]> => requests.get(`/workout/exercises/${workoutId}/${dateRecorded}`)
}

const Teams = {
    list : (orgId : string) : Promise<ITeams[]> => requests.get(`/team/all/${orgId}`),
    detailed: (id: string) : Promise<IDetailedTeam> => requests.get(`/team/detailed/${id}`),
    create: (team : IDetailedTeam) => requests.post("/team/create" , team),
    activate: (id: string) => requests.put(`/team/activate/${id}`, {}),
    deactivate:  (id: string) => requests.put(`/team/deactivate/${id}`, {})
}

export default {
    User,
    Messages,
    Memberships,
    Workouts,
    Athlete,
    Coaches,
    Teams
}